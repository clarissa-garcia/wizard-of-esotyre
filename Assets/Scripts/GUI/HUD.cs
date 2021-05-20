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
    public GameObject pauseMenu;

    public TextMeshProUGUI questText;

    public TextMeshProUGUI recipeListText;
    
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
            //Inventory.GenDemoInventory();
            loadDemoInventory = false;
        }
        QuestManager.OnQuestChange += UpdateQuestText;
        UpdateQuestText();
        DrawInventory();
    }

    /// <summary>
    /// Updates inventory bar to show current inventory.
    /// </summary>
    public void DrawInventory()
    {
        int i = 0;

        // Iterate through each item instance
        foreach(ItemInstance itemInstance in PlayerInventory.Instance.inventory)
        {
            if(itemInstance.item != null){
                inventorySlots[i].SetIconAndCount(itemInstance.item.icon, itemInstance.amount);
                inventorySlots[i].setItem(itemInstance.item);
                i++;
            }
            else break;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
                ResumeGame();
            else
                PauseGame();

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

    private void PauseGame()
    {
        EnableCursor();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        DisableCursor();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void UpdateQuestText(){
        switch(QuestManager.Instance.quest){
            case Quest.COFFEE:
                questText.text = "Quest: Make Coffee";
                recipeListText.text = "-Water: Outside\n-Coffee: Inventory\n " +
                "Go inside the tower and find the workstation. Follow the recipe in your book";
                break;
            case Quest.REPAIR_BRIDGE:
                questText.text = "Quest: Repair the bridge";
                recipeListText.text = "-Wood: Outside\n-Crystal: Tower\n " +
                "Find wood, and then the crystals inside the tower. Follow the recipe to make a wand of repair"
                +"Go to the bridge and click to repair.";
                break;
            case Quest.ENTER_FOREST:
                questText.text = "Quest: Enter the forest";
                recipeListText.text = "-Boots: Town\n-Metal: Town\n " +
                "Craft the Boots of Jumping, which will allow you to jump higher. Once in the forest find the cave.";
                break;
            case Quest.ENTER_CAVE:
                questText.text = "Quest: Enter the cave";
                break;
            
        }
    }

    private void OnDestroy() {
        QuestManager.OnQuestChange -= UpdateQuestText;
    }
}
