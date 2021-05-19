using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Instance of an item for inventory. Contains item and the amount.
/// </summary>
public class ItemInstance
{    
    public Item item;
    public int amount;

    public ItemInstance(Item _item, int _amount) {
        this.item = _item;
        this.amount = _amount;
    }
}