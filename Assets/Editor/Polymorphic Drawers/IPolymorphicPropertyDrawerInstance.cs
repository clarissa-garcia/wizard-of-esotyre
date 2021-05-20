using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 

public interface IPolymorphicPropertyDrawerInstance<TScriptableObject> where TScriptableObject : ScriptableObject
{
    void OnGUI(Rect position, SerializedObject propertyObj, GUIContent label);
    float GetPropertyHeight(SerializedObject propertyObj, GUIContent label);
}