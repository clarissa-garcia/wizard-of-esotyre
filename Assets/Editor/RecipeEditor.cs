using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Recipe))]
public class RecipeEditor : Editor 
{
    SerializedProperty componentsProp; 
    SerializedProperty orderedProp;
    SerializedProperty amountProp;

    ComponentType compToAddType = ComponentType.ITEM;

    private List<bool> componentFoldouts; 

    Recipe recipe; 

    private void OnEnable() {
        componentsProp = serializedObject.FindProperty("componentList");

        componentFoldouts = new List<bool>(componentsProp.arraySize);

        for(int i = 0; i < componentFoldouts.Capacity; i++){
            componentFoldouts.Add(false);
        }
    }

    
    public override void OnInspectorGUI()
    {
        recipe = (Recipe) target; 
        serializedObject.Update();  // Update serialized object

        recipe.result = (Item)EditorGUILayout.ObjectField("Result Item:", recipe.result, typeof(Item), false);
        recipe.amount = EditorGUILayout.IntField("Items created:", recipe.amount);
        recipe.isOrdered = EditorGUILayout.Toggle("Ordered?", recipe.isOrdered); // Ordered Toggle
        componentsProp.arraySize = EditorGUILayout.IntField("Size", componentsProp.arraySize); // Change Array size

        
        UpdateFoldoutSize(); // Keep the number of foldouts the same as the number of elements

        for(int i = 0; i < componentsProp.arraySize; i++){
            SerializedProperty _component = componentsProp.GetArrayElementAtIndex(i);

            componentFoldouts[i] = EditorGUILayout.BeginFoldoutHeaderGroup(componentFoldouts[i], "Component " + i);
            // Only show property on foldout
            if(componentFoldouts[i]){
                EditorGUI.PropertyField(new Rect(EditorGUI.indentLevel, i * 100, 100, 100), _component);
            }
            EditorGUILayout.EndFoldoutHeaderGroup(); // Close foldout group
        }

        // Add a new component to the recipe
        EditorGUILayout.BeginHorizontal();

        compToAddType = (ComponentType)EditorGUILayout.EnumPopup(compToAddType);    // Type Dropdown
        if(GUILayout.Button("Add Component")){                                      // Add new component
            
            RecipeComponent[] temp = new RecipeComponent[componentsProp.arraySize + 1];
            recipe.componentList.CopyTo(temp, 0);
            recipe.componentList = temp;
            recipe.componentList[recipe.componentList.Length - 1] = CreateNewRecipeComponent(compToAddType);
            serializedObject.Update();
        }
        EditorGUILayout.EndHorizontal();
        

        serializedObject.ApplyModifiedProperties();
    }

    /// <summary>
    /// Creates a new recipe component asset
    /// </summary>
    /// <param name="type"> Component Type to add </param>
    /// <returns> New RecipeComponent scriptable object </returns>
    private RecipeComponent CreateNewRecipeComponent(ComponentType type){
        RecipeComponent newComponent = null;

        switch(type){
            case ComponentType.ITEM:
                newComponent = ScriptableObject.CreateInstance<ItemComponent>(); 
                break; 
            case ComponentType.STIR:
                newComponent = ScriptableObject.CreateInstance<StirComponent>(); 
                break; 
            case ComponentType.ENCHANTMENT:
                newComponent = ScriptableObject.CreateInstance<EnchantmentComponent>(); 
                break; 
        }

        if(newComponent != null){
            string path = "Assets/Resources/Recipes/Components/New" + newComponent.GetType(); 

            // Check if name doesn't already exist
            if(AssetDatabase.LoadAssetAtPath<RecipeComponent>(path + ".asset") != null){
                int i = 1;;

                // Change path until a valid number is found
                while(AssetDatabase.LoadAssetAtPath<RecipeComponent>(path + " " + i + ".asset") != null)
                    i++; 

                path += " " + i + ".asset"; // update path with number
            }
            else
                path += ".asset";

            AssetDatabase.CreateAsset(newComponent, path); // create asset
            AssetDatabase.SaveAssets(); // save asset
        }

        return newComponent; 
    }
    
    /// <summary>
    /// Updates the number of foldout booleans in the FoldoutCount to match the number of elements displayed.
    /// </summary>
    private void UpdateFoldoutSize(){
        if(componentsProp.arraySize == 0){
            componentFoldouts.Clear();
        }
        else if(componentsProp.arraySize < componentFoldouts.Count){
            componentFoldouts.RemoveRange(componentsProp.arraySize -1, componentFoldouts.Count - componentsProp.arraySize);
        }
        else if(componentsProp.arraySize > componentFoldouts.Count){
            while(componentsProp.arraySize != componentFoldouts.Count)
                componentFoldouts.Add(false);
        }
    }
}
