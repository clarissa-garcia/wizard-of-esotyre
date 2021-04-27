using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class workstationButton : MonoBehaviour
{
    public void ClickedItem()
    {

        //Check that the button clicked has an image (is a non-empty item)
        // Then use the image name to look up the player's inventory item to update the quantity
        // in code and on the screen

        Scene currentScene = SceneManager.GetActiveScene();

        //This is the workstation scene where recipes are created
        // If a user clicks in this scene, detract the clicked item 
        // to the cauldron
        if (currentScene.name == "Workstation")
        {
            if (gameObject.GetComponent<ItemSlot>().itemHeld != null)
            {
                Item itemHeld = gameObject.GetComponent<ItemSlot>().itemHeld;
                int itemHeldNum = Inventory.getItemCount(itemHeld);
                Debug.Log("Item to be removed is: " + itemHeld.name);

                Inventory.RemoveItem(itemHeld);
                 // Add item deducted to the caulron
                CauldronInventory.AddItem(itemHeld);
                //Access the item slot to update the inventory count
                ItemSlot currentItemSlot = GetComponent<ItemSlot>();
                currentItemSlot.UpdateItemCount(itemHeldNum - 1);
            }
            
        }
    }
}
