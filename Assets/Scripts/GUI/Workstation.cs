using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Workstation : MonoBehaviour
{

    public static Sprite[] itemSprites;
    HUD playerHUD;
    private StirCounter stirCounter;
    public GameObject circle;

    private void Start()
    {
        playerHUD = GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>();
        playerHUD.EnableCursor();
        itemSprites = Resources.LoadAll<Sprite>("ItemIcons");
        stirCounter = GameObject.Find("Stir Count").GetComponent<StirCounter>();
    }

    /// <summary>
    /// Called by brew button in workstation GUI
    /// </summary>
    public void BrewRecipe()
    {
        //Fetch the items given to the cauldron
        // Debug.Log("IN CAULDRON: ");
        // foreach (KeyValuePair<Item, int> entry in CauldronInventory.GetAll())
        // {
        //     Debug.Log(entry.Key.name);
        // }
        // Debug.Log("END OF CAULDRON LIST");

        Item returnItem = RecipeController.CheckRecipe(CauldronInventory.GetAll(), stirCounter.GetDirection(), stirCounter.GetNumStirs());
        Debug.Log(returnItem.name);
        //Add in logic checks from workstation (numbers of stirs, direction, etc)
        //After verifying player's recipe, add new item to inventory
        //Example of created item added: 
        Inventory.AddItem(returnItem);
        playerHUD.DrawInventory();
        // "Empty" the cauldron by turning the circle in it transparent
        circle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
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
