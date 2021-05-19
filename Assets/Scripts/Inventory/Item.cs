using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
[CreateAssetMenu(fileName = "Item.asset", menuName = "Inventory System/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public int ID = 0;
    public GameObject itemObject = null;
    public Sprite icon = null;
    public bool isUnique = false;
}
