using UnityEngine;
using UnityEditor;

public class ItemComponentDrawer : BaseRecipeComponentDrawer{
 
    protected override void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
    {
        propertyObj.Update();
        SerializedProperty _item = propertyObj.FindProperty("item");
        EditorGUILayout.PropertyField(_item, true);
        propertyObj.ApplyModifiedProperties();
    }
}