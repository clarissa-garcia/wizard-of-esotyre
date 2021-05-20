using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 
public abstract class APolymorphicPropertyDrawer<TScriptableObject, TPropertyDrawer> : PropertyDrawer where TScriptableObject : ScriptableObject where TPropertyDrawer : PropertyDrawer, IPolymorphicPropertyDrawerInstance<TScriptableObject>
{
    private static Dictionary<Type, TPropertyDrawer> m_TypeToPropertyDrawerMappings;
 
    protected void TryInitPropertyMappings()
    {
        if (m_TypeToPropertyDrawerMappings == null)
        {
            m_TypeToPropertyDrawerMappings = new Dictionary<Type, TPropertyDrawer>();
            DoInitPropertyMappings();
        }
    }
 
    protected abstract void DoInitPropertyMappings();
 
    protected void RegisterPropertyDrawer(Type type, TPropertyDrawer propertyDrawer)
    {
        if (type.IsAbstract)
        {
            throw new Exception($"Unable to register {type.Name} because it is abstract");
        }
 
        m_TypeToPropertyDrawerMappings.Add(type, propertyDrawer);
    }
 
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        TryInitPropertyMappings();
 
        TPropertyDrawer drawer = GetPropertyDrawer(property);
        EditorGUILayout.PropertyField(property, null, false);
        if (drawer != null)
        {
            SerializedObject propertyObj = GetSerializedObject(property);
            drawer.OnGUI(position, propertyObj, label);
        }
    }
 
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        TryInitPropertyMappings();

        SerializedObject tmp = GetSerializedObject(property); 
        if(tmp != null){
            SerializedObject propertyObj = GetSerializedObject(property);
            TPropertyDrawer drawer = GetPropertyDrawer(property);
            return drawer.GetPropertyHeight(propertyObj, label);
        }
        return EditorGUIUtility.singleLineHeight;
    }
 
    private SerializedObject GetSerializedObject(SerializedProperty property)
    {
        if(property.objectReferenceValue == null) return null; 
        SerializedObject newObj = new SerializedObject(property.objectReferenceValue);
        return newObj;
    }
 
    private TPropertyDrawer GetPropertyDrawer(SerializedProperty property)
    {
        if(property == null || property.objectReferenceValue == null) return null; 

        Type propertyType = property.objectReferenceValue.GetType();
        m_TypeToPropertyDrawerMappings.TryGetValue(propertyType, out var drawer);
        
        return drawer;
    }
}