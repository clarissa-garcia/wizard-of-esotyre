using UnityEngine;
using UnityEditor;
public enum StirDirection
    {
        CLOCKWISE,
        COUNTERCLOCKWISE
    }

[System.Serializable]
[CreateAssetMenu(fileName = "StirComponent", menuName = "Recipe System/Components/Stir Component", order = 1)]
public class StirComponent : RecipeComponent {
    public StirDirection direction = StirDirection.CLOCKWISE;
    public int amount = 1;

    private void OnEnable() {
        base.type = ComponentType.STIR;
    }
}