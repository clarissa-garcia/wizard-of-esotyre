using UnityEngine;
using UnityEditor;

[System.Serializable]
[ExecuteInEditMode]
[CreateAssetMenu(fileName = "Item.asset", menuName = "Inventory System/Item")]
public class Item : ScriptableObject, RecipeComponent
{
    public string itemName = "New Item";
    public int ID = 0;
    public GameObject itemObject = null;
    public Sprite icon = null;
    public bool isUnique = false;

    public RecipeComponent ShowComponent(){
        return (RecipeComponent)EditorGUILayout.ObjectField("Item", this, typeof(RecipeComponent), false); 
    }
}
