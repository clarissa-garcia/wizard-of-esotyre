using UnityEngine;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(fileName = "ItemComponent", menuName = "Recipe System/Components/Item Component", order = 0)]
public class ItemComponent : RecipeComponent {
    private void OnEnable() {
        base.type = ComponentType.ITEM;
    }

    public Item item;
}