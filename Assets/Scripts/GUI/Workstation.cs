using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workstation : MonoBehaviour
{

    private List<Item> cauldronInventory = new List<Item>();
    public static Sprite[] itemSprites;
    HUD playerHUD;

    private void Start()
    {
        playerHUD = GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>();
        playerHUD.DisableCrosshair();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        itemSprites = Resources.LoadAll<Sprite>("ItemIcons");
    }

    /// <summary>
    /// Called by brew button in workstation GUI
    /// </summary>
    public void BrewRecipe()
    {
        //Fetch the items given to the cauldron
        Debug.Log("IN CAULDRON: ");
        foreach (KeyValuePair<Item, int> entry in CauldronInventory.GetAll())
        {
            Debug.Log(entry.Key.name);
        }
        Debug.Log("END OF CAULDRON LIST");
        //Add in logic checks from workstation (numbers of stirs, direction, etc)
        //After verifying player's recipe, add new item to inventory
        //Example of created item added: 
        Inventory.AddItem(new Item("Sword", itemSprites[49]));
        playerHUD.DrawInventory();

        //Inventory.AddItem(new Item("Candle", "Sprites/candle"));
    }

    /// <summary>
    /// Called by return to tower button. Loads towerInterior scene. 
    /// </summary>
    public void ReturnToTower()
    {
        SceneManager.LoadScene("TowerInside");
    }

    // Update is called once per frame
    /*public void AddCauldronItem(Item newItem)
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
        foreach (KeyValuePair<Item, int> entry in CauldronInventory.GetAll())
        {
            Debug.Log(entry.Key.name);
        }
    }*/
}
