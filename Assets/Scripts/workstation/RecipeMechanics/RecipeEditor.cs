using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Recipe))]
public class RecipeEditor : Editor 
{
    SerializedProperty componentsProp; 
    SerializedProperty orderedProp;

    private void OnEnable() {
        componentsProp = serializedObject.FindProperty("componentList");
        orderedProp = serializedObject.FindProperty("isOrdered");
    }

    ComponentType compType = ComponentType.ITEM;
    public override void OnInspectorGUI()
    {
        Recipe recipe = (Recipe)target; 
        recipe.isOrdered = EditorGUILayout.Toggle("Ordered?:", recipe.isOrdered);

        EditorGUILayout.BeginHorizontal();
        compType = (ComponentType)EditorGUILayout.EnumPopup(compType);
        if(GUILayout.Button("Add Component")){
            RecipeComponent newComponent = null;

            switch(compType){
                case ComponentType.ITEM:
                    newComponent = CreateInstance<ItemComponent>(); 
                    break; 
                case ComponentType.STIR:
                    newComponent = CreateInstance<StirComponent>(); 
                    break; 
                case ComponentType.ENCHANTMENT:
                    newComponent = CreateInstance<EnchantmentComponent>(); 
                    break; 
            }
        }
        EditorGUILayout.EndHorizontal();

        serializedObject.Update();

        SerializedProperty _compList = serializedObject.FindProperty("componentList");

        // Ofcourse you also want to change the list size here
        _compList.arraySize = EditorGUILayout.IntField("Size", _compList.arraySize);

        for (int i = 0; i < _compList.arraySize; i++)
        {
            var component = _compList.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(component, new GUIContent("Component " + i), true);
        }

        // Note: You also forgot to add this
        serializedObject.ApplyModifiedProperties();

        // foreach(RecipeComponent component in recipe.ComponentList){
        //     component.ShowComponent();
        // }

        // item.itemName = EditorGUILayout.TextField("Item Name:", item.itemName);
        // item.ID = EditorGUILayout.IntField("ID: ", item.ID);
        // item.isUnique = EditorGUILayout.Toggle("Unique:", item.isUnique);
        // item.itemObject = (GameObject)EditorGUILayout.ObjectField("Object:", item.itemObject, typeof(GameObject), false);
        // item.icon = (Sprite)EditorGUILayout.ObjectField("Icon:", item.icon, typeof(Sprite), false);
    }

}
