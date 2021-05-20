using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnchantmentComponentDrawer : BaseRecipeComponentDrawer
{
    protected override void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
    {
        propertyObj.Update();
        SerializedProperty _syllables = propertyObj.FindProperty("syllables");
        _syllables.arraySize = EditorGUILayout.IntField("Size", _syllables.arraySize); // Change Array size
        if(_syllables.arraySize < 1){
            _syllables.arraySize = 1; 
            propertyObj.ApplyModifiedProperties();
        }
           

        
        for(int i = 0; i < _syllables.arraySize; i++){
            SerializedProperty _component = _syllables.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(_component);
        }
        propertyObj.ApplyModifiedProperties();
    }
}
