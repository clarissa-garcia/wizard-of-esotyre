using UnityEngine;

public enum ComponentType{
    ITEM,
    STIR,
    ENCHANTMENT
}

[System.Serializable]
public abstract class RecipeComponent : ScriptableObject{
    public ComponentType type;

    
}