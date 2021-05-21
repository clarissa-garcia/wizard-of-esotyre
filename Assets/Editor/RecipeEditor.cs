using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Recipe))]
public class RecipeEditor : Editor 
{

    //ComponentType compToAddType = ComponentType.ITEM;

    private List<bool> componentFoldouts; 

    Recipe recipe; 
    List<RecipeComponent> components; 
    int selectedIndex = 0; 

    private void OnEnable() {
        recipe = (Recipe) target; 
        if(recipe.componentList != null){
            components = recipe.componentList;
            componentFoldouts = new List<bool>(components.Capacity);

            for(int i = 0; i < componentFoldouts.Capacity; i++){
                componentFoldouts.Add(false);
            }
        }
            
        // componentsProp = serializedObject.FindProperty("componentList");

        
    }

    
    public override void OnInspectorGUI()
    {
        components = recipe.componentList;
        recipe.result = (Item)EditorGUILayout.ObjectField("Result Item:", recipe.result, typeof(Item), false);
        recipe.amount = EditorGUILayout.IntField("Items created:", recipe.amount);
        recipe.isOrdered = EditorGUILayout.Toggle("Ordered?", recipe.isOrdered); // Ordered Toggle

        UpdateFoldoutSize(); // Keep the number of foldouts the same as the number of elements
        
        if(components != null){
            for(int i = 0; i < recipe.componentList.Count; i++){
                if(components[i] != null){
                    EditorGUILayout.BeginHorizontal();


                    // Buttons
                    EditorGUILayout.BeginVertical(GUILayout.MaxWidth(50));
                    // Delete Component 
                    if(GUILayout.Button("DEL", GUILayout.Width(50))) {
                        DeleteComponent(i);
                        i++; 
                        if(i >= recipe.componentList.Count){
                            EditorGUILayout.EndVertical();
                            EditorGUILayout.EndHorizontal();
                            return; 
                        }
                    }; 
                    EditorGUILayout.BeginHorizontal();
                    if(GUILayout.Button("↑", GUILayout.Width(25))) ShiftComponentUp(i);
                    if(GUILayout.Button("↓", GUILayout.Width(25))) ShiftComponentDown(i);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndVertical();


                    GUILayout.Space(10);    // Add space between buttons and dropdown


                    EditorGUILayout.BeginVertical(); 
                    componentFoldouts[i] = EditorGUILayout.BeginFoldoutHeaderGroup(componentFoldouts[i], "Component " + i + " (" + components[i].GetType() + ")");
                    if(componentFoldouts[i]){
                        if(components[i] is Item){
                            EditorGUILayout.BeginHorizontal();
                            components[i] = (RecipeComponent)EditorGUILayout.ObjectField("Item", (Item)components[i], typeof(Item), false); 
                            EditorGUILayout.EndHorizontal();
                        }
                        if(components[i] is Enchantment){
                            Enchantment _enchatnment = (Enchantment)components[i]; 
                            
                            EditorGUILayout.BeginHorizontal(); 
                            EditorGUILayout.BeginVertical(); 
                            components[i] = (RecipeComponent)EditorGUILayout.ObjectField("Enchantment", (Enchantment)components[i], typeof(Enchantment), false); 
                            components[i].ShowComponent();
                            EditorGUILayout.EndVertical();
                            EditorGUILayout.EndHorizontal();
                        }
                        if(components[i] is Stir){
                            components[i].ShowComponent();
                        }
                    }
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndFoldoutHeaderGroup();
                    EditorGUILayout.EndHorizontal();
                    
                } 
            }
        }

        // Add a new component to the recipe
        
        selectedIndex = EditorGUILayout.Popup(selectedIndex, new string [] {"Add component",
                                                                            "Item",
                                                                            "Stir",
                                                                            "Enchantment"});
        CreateNewRecipeComponent(selectedIndex);
        selectedIndex = 0; 
        components = recipe.componentList;
    }

    private void DeleteComponent(int i)
    {
        components.RemoveAt(i);
        UpdateFoldoutSize(); 
    }

    private void ShiftComponentDown(int i){
        if(i == components.Count - 1) return;
        
        Swap2(components, i, i+1);
        Swap2(componentFoldouts, i, i+1);
    }

    private void ShiftComponentUp(int i){
        if(i == 0) return;
        Swap2(components, i, i-1);
        Swap2(componentFoldouts, i, i-1);
    }

    private void Swap2<T>(List<T> ls, int i, int j){
        var tmp = ls[i];
        ls[i] = ls[j];
        ls[j] = tmp; 
    }

    /// <summary>
    /// Creates a new recipe component asset
    /// </summary>
    /// <param name="type"> Component Type to add </param>
    /// <returns> New RecipeComponent scriptable object </returns>
    private void CreateNewRecipeComponent(int type){
        RecipeComponent newComponent = null;

        switch(type){
            case 1:
                newComponent = ScriptableObject.CreateInstance<Item>(); 
                break; 
            case 2:
                newComponent = ScriptableObject.CreateInstance<Stir>(); 
                break; 
            case 3:
                newComponent = ScriptableObject.CreateInstance<Enchantment>(); 
                break; 
            default:
                return; 
        }

        components.Add(newComponent);

        // if(newComponent != null){
        //     string path = "Assets/Resources/Recipes/Components/New" + newComponent.GetType(); 

        //     // Check if name doesn't already exist
        //     if(AssetDatabase.LoadAssetAtPath<RecipeComponent>(path + ".asset") != null){
        //         int i = 1;;

        //         // Change path until a valid number is found
        //         while(AssetDatabase.LoadAssetAtPath<RecipeComponent>(path + " " + i + ".asset") != null)
        //             i++; 

        //         path += " " + i + ".asset"; // update path with number
        //     }
        //     else
        //         path += ".asset";

        //     AssetDatabase.CreateAsset(newComponent, path); // create asset
        //     AssetDatabase.SaveAssets(); // save asset
        // }

        //return newComponent; 
    }
    
    /// <summary>
    /// Updates the number of foldout booleans in the FoldoutCount to match the number of elements displayed.
    /// </summary>
    private void UpdateFoldoutSize(){
        if(components.Count == 0){
            componentFoldouts.Clear();
        }
        else if(components.Count < componentFoldouts.Count){
            componentFoldouts.RemoveRange(components.Count -1, componentFoldouts.Count - components.Count);
        }
        else if(components.Count > componentFoldouts.Count){
            while(components.Count != componentFoldouts.Count)
                componentFoldouts.Add(false);
        }
    }
}
