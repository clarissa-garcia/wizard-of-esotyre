using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Workstation : MonoBehaviour
{

    private List<Item>cauldronInventory = new List<Item>();
    HUD playerHUD; 

    private void Start()
    {
        playerHUD = GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>();
        playerHUD.DisableCrosshair();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Called by brew button in workstation GUI
    /// </summary>
    public void BrewRecipe()
    {
        // TODO: Add brew logic here

        /*public void OnFinishedRecipe() {
        //Fetch the array of items given to the cauldron
        cauldronObject = GameObject.FindWithTag("Cauldron");
        Item[] cauldronArray = cauldronObject.GetComponent<CauldronInventory>().cauldronInventory;
        for (int i = 0; i < cauldronArray.Length; i++) {
        if (cauldronArray[i]!=null)
         Debug.Log(cauldronArray[i].itemName);
        }
        //Add in logic checks from workstation (numbers of stirs, direction, etc)
        //After verifying player's recipe, add new item to inventory
        //Example of created item added: 
        Inventory.AddItem(new Item("Candle", "Sprites/candle"));
    }*/
    }

    /// <summary>
    /// Called by return to tower button. Loads towerInterior scene. 
    /// </summary>
    public void ReturnToTower()
    {
        SceneManager.LoadScene("TowerInside");
    }

    // Update is called once per frame
    public void AddCauldronItem(Item newItem)
    {
        for (int i = 0; i < cauldronInventory.Count; i++)
        {
            if (cauldronInventory[i] == null)
            {
                cauldronInventory[i] = newItem;
                PrintCauldronInventory();
                return;
            }
        }
    }

    public void PrintCauldronInventory()
    {
        Debug.Log("Start of inventory:");
        for (int i = 0; i < cauldronInventory.Count; i++)
        {
            if (cauldronInventory[i] != null)
            {
                Debug.Log(cauldronInventory[i].name);
            }
        }
        Debug.Log("End of inventory");
    }
}
