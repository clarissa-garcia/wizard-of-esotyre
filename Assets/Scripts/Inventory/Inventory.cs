using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Inventory System/Inventory", fileName = "Inventory.asset")]
public class Inventory : ScriptableObject
{

    /// <summary>
    /// The Inventory
    /// </summary>
    public ItemInstance[] inventory;

    /// <summary>
    /// Checks if a given index slot is empty
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool SlotEmpty(int index){
        return (inventory[index] == null || inventory[index].item == null); 
    }

    /// <summary>
    /// Get item from specified index.
    /// </summary>
    /// <param name="index"> Index to get item from </param>
    /// <param name="item"> Item removed </param>
    /// <returns> True if item is present, false otherwise. </returns>
    public bool GetItem(int index, out ItemInstance item){
        if(SlotEmpty(index)){
            item = null;
            return false;
        }
        
        item = inventory[index];
        return true;
    }

    /// <summary>
    /// Remove item at specifed index
    /// </summary>
    /// <param name="index"> Index to remove from </param>
    /// <returns> Item if successfully removed, null otherwise. </returns>
    public Item RemoveItem(int index){

        Item item = null;

        if(!SlotEmpty(index)){
            item = inventory[index].item;
            if(inventory[index].amount > 1)
                item = inventory[index].item;
                
            else{
                inventory[index] = null;
            }
        }

        return item;
    }
    

    /// <summary>
    /// Adds item instance to inventory
    /// </summary>
    public int AddItem(Item item){

        for(int i = 0; i < inventory.Length; i++){
            // Empty slot encountered, place item
            if(SlotEmpty(i)){
                inventory[i] = new ItemInstance(item, 1);
                return i; 
            }
            // Item exists in inventory, place item
            else if(inventory[i].item == item){
                inventory[i].amount++;
                return i;
            }
        }

        return -1; // No room in inventory
    }
}
