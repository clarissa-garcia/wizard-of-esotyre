using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemComponent))]
public class ItemComponentDrawer: PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        SerializedProperty item = property.FindPropertyRelative("item");
        SerializedProperty amount = property.FindPropertyRelative("property");
    }
}