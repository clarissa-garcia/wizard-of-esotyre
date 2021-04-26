using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int inventoryMax = 7;
    public GameObject playerobject;
    public Item[] playerInventory;
    public Item_Map playerMap = new Item_Map();
    public GameObject inventoryPanel;

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
        playerMap.AddMapItem("Sprites/branch", playerInventory[2]);
        DrawPlayerInventory quickdraw = inventoryPanel.GetComponent<DrawPlayerInventory>();
        quickdraw.drawInventory(playerInventory);

        DontDestroyOnLoad(this);
    }

    public void addItem(Item pickedUpItem) {
        //First, find out if player already has item or not to just add on to quantity
        for (int i = 0; i < playerInventory.Length; i++) {
            if (playerInventory[i]!= null && playerInventory[i].itemName == pickedUpItem.itemName)
            {
                playerInventory[i].setQuantity(playerInventory[i].getQuantity() + pickedUpItem.getQuantity());
                inventoryPanel.GetComponent<DrawPlayerInventory>().drawInventory(playerInventory);
                return;
            }
        }
        //Player doesn't have item, so this is a new item. Add accordingly
        for (int i = 0; i < playerInventory.Length; i++)
        {
            if (playerInventory[i] == null) {
                playerInventory[i] = pickedUpItem;
                inventoryPanel.GetComponent<DrawPlayerInventory>().drawInventory(playerInventory);
                return;
            }
        }
        //Else, the player has no more empty spaces in inventory. Do not add item
    }

    public void removeItem(Item droppedItem, int quantity) {
        //First, find item player has and subtract from quantity
        for (int i = 0; i < playerInventory.Length; i++)
        {
            if (playerInventory[i]!= null && playerInventory[i].itemName == droppedItem.itemName)
            {
                playerInventory[i].setQuantity(playerInventory[i].getQuantity() - quantity);
                //Check if the quantity is zero or less. If it is, you want to remove the item from the player's inventory
                if (playerInventory[i].getQuantity() <= 0) {
                    playerInventory[i] = null;
                    //Don't forget to shift remaining items to the left a space
                    while (i < (playerInventory.Length - 1)) {
                        playerInventory[i] = playerInventory[i + 1];
                        i++;
                    }
                    inventoryPanel.GetComponent<DrawPlayerInventory>().drawInventory(playerInventory);
                    return;
                }
            }
        }
    }
}
