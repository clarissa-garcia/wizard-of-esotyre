using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int inventoryMax = 7;
    public GameObject playerobject;
    public Item[] playerInventory;
    public Item_Map playerMap = new Item_Map();

    // Start is called before the first frame update
    void Start()
    {
        //Create a sample inventory a player might have
        playerInventory = new Item[inventoryMax];
        playerobject = GameObject.FindWithTag("Player");
        //It is necessary to add each item to the player's Item Map lookup for the inventory
        //to update the player's data based on screen clicks.
        // Please don't forget to do so each time an item is added to player's inventory
        playerInventory[0] = new Item("Green Potion", "Sprites/green_potion", 1);
        playerMap.AddMapItem("Sprites/green_potion", playerInventory[0]);
        playerInventory[1] = new Item("Red Potion", "Sprites/red_potion", 3);
        playerMap.AddMapItem("Sprites/red_potion", playerInventory[1]);
        playerInventory[2] = new Item("Branch", "Sprites/branch", 4);
        playerMap.AddMapItem("Sprites/branch", playerInventory[1]);
    }

    public void addItem(Item pickedUpItem) {
        //First, find out if player already has item or not
        for (int i = 0; i < playerInventory.Length; i++) {
            if (playerInventory[i].itemName == pickedUpItem.itemName)
            {
                playerInventory[i].setQuantity(playerInventory[i].getQuantity() + pickedUpItem.getQuantity());
                //call drawInventory
                return;
            }
        }
        //Player doesn't have item, so this is a new item. Add accordingly
        for (int i = 0; i < playerInventory.Length; i++)
        {
            if (playerInventory[i] == null) {
                playerInventory[i] = pickedUpItem;
                //call drawInventory
                return;
            }
        }
        //Else, the player has no more empty spaces in inventory. Do not add item
    }
}
