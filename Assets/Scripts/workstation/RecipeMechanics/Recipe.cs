using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe System/Recipe", order = 0)]
public class Recipe : ScriptableObject {
    public bool isOrdered; 
    
    [SerializeField]
    public RecipeComponent[] componentList; 
}