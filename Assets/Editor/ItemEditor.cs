using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]
public class ItemEditor : Editor 
{

    public override void OnInspectorGUI()
    {
        Item item = (Item)target; 

        item.itemName = EditorGUILayout.TextField("Item Name:", item.itemName);
        item.ID = EditorGUILayout.IntField("ID: ", item.ID);
        item.isUnique = EditorGUILayout.Toggle("Unique:", item.isUnique);
        item.itemObject = (GameObject)EditorGUILayout.ObjectField("Object:", item.itemObject, typeof(GameObject), false);
        item.icon = (Sprite)EditorGUILayout.ObjectField("Icon:", item.icon, typeof(Sprite), false);
    }
}
