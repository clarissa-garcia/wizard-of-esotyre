using UnityEngine;

public enum StirDirection
    {
        CLOCKWISE,
        COUNTERCLOCKWISE
    }

[System.Serializable]
[CreateAssetMenu(fileName = "StirComponent", menuName = "Recipe System/Components/Stir Component", order = 1)]
public class StirComponent : RecipeComponent {
    

    private void OnEnable() {
        base.type = ComponentType.STIR;
    }

    public StirDirection direction = StirDirection.CLOCKWISE;
    public int amount = 1;
}