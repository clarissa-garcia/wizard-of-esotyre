using UnityEngine;
using UnityEditor;


[System.Serializable]
[CreateAssetMenu(fileName = "EnchantmentComponent", menuName = "Recipe System/Components/Enchantment Component", order = 1)]
public class EnchantmentComponent : RecipeComponent {
    
    private void OnEnable() {
        base.type = ComponentType.ENCHANTMENT;
    }

    public string[] syllables;
}