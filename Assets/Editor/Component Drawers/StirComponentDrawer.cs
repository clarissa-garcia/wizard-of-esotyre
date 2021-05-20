using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StirComponentDrawer : BaseRecipeComponentDrawer
{
    protected override void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
    {
        propertyObj.Update();
        SerializedProperty _direction = propertyObj.FindProperty("direction");
        SerializedProperty _amount = propertyObj.FindProperty("amount");
        EditorGUILayout.PropertyField(_direction);
        EditorGUILayout.PropertyField(_amount);
        propertyObj.ApplyModifiedProperties();
    }
}
