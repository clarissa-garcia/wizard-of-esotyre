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
    public GameObject recipeBook;
    
    private int cursorSemaphore;
    private PlayerController playerController = null; 

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindWithTag("Player"))
            playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        cursorSemaphore = 0;

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
    public void Update()
    {  
        /* Recipe Book */ 
        if (Input.GetKeyDown("b"))
        {
            recipeBook.SetActive(!recipeBook.activeSelf);

            if (recipeBook.activeSelf)
                EnableCursor();
            else
                DisableCursor();
        }
    }

    public int EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DisableCrosshair();
        if(playerController) playerController.CameraMovement(false);
        return ++cursorSemaphore;
    }

    public int DisableCursor()
    {
        if (--cursorSemaphore <= 0)
        {
            cursorSemaphore = 0;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (playerController) playerController.CameraMovement(true);
            EnableCrosshair();
        }

        return cursorSemaphore;
    }

    private void EnableCrosshair()
    {
        crossHair.SetActive(true); 
    }

    private void DisableCrosshair()
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
