using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe System/Recipe", order = 0)]
public class Recipe : ScriptableObject {
    public bool isOrdered = true; 

    public Item result = null;

    public int amount = 1; 
    public RecipeComponent[] componentList; 
}