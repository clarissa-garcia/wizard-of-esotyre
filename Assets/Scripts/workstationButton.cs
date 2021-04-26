using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class workstationButton : MonoBehaviour
{
    private GameObject playerobject;
    private GameObject cauldronObject;
    /*public void ClickedItem()
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
            Image imageToChange = transform.GetChild(0).GetComponent<Image>();
            if (imageToChange.sprite != null)
            {
                playerobject = GameObject.FindWithTag("Player");
                Item_Map playerMap = playerobject.GetComponent<PlayerInventory>().playerMap;
                Debug.Log(imageToChange.sprite.name);
                playerMap.itemDictionary.TryGetValue("Sprites/" + imageToChange.sprite.name, out Item value);
                //Once you get value, update it in the player's inventory
                Inventory.RemoveItem(value);
                // Add item deducted to the cauldron
                cauldronObject = GameObject.FindWithTag("Cauldron");
                cauldronObject.GetComponent<CauldronInventory>().addItem(value);
                //sorry for long line, there was no other way to access inventory panel from a button call
                playerobject.GetComponent<PlayerInventory>().inventoryPanel.GetComponent<DrawPlayerInventory>().drawInventory(playerobject.GetComponent<PlayerInventory>().playerInventory);
            }
        }
    }*/
}
