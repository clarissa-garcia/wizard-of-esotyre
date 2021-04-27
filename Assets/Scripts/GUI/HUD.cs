using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
/// <summary>
/// Mechanics for player GUI HUD. Including crosshair, inventory bar, etc. 
/// </summary>
public class HUD : MonoBehaviour
{
    [Header("Debug")]
    public bool loadDemoInventory = false;

    [Header("GUI References")]
    public ItemSlot[] inventorySlots;
    public GameObject popUp;
    public TextMeshProUGUI popUpText;
    public GameObject crossHair;
    

    // Start is called before the first frame update
    void Start()
    {
        if (loadDemoInventory)
        {
            Inventory.GenDemoInventory();
            loadDemoInventory = false;
        }
            
        DrawInventory();
    }

    /// <summary>
    /// Updates inventory bar to show current inventory.
    /// </summary>
    public void DrawInventory()
    {
        int i = 0;

        foreach (KeyValuePair<Item, int> entry in Inventory.GetAll())
        {
            inventorySlots[i].SetIconAndCount(entry.Key.GetSprite(), entry.Value);
            inventorySlots[i].setItem(entry.Key);
            i++;
        }

        while(i < 7)
        {
            inventorySlots[i].ClearSlot();
            i++;
        }
    }

    public void EnableCrosshair()
    {
        crossHair.SetActive(true); 
    }

    public void DisableCrosshair()
    {
        crossHair.SetActive(false);
    }

    public void ShowPopUp(string text)
    {
        popUp.SetActive(true);
        popUpText.text = text;
    }

    public void HidePopUp()
    {
        popUp.SetActive(false);
    }
}
