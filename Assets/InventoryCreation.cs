using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCreation : MonoBehaviour
{
    private string beginningImageString = "Sprites/";
    public GameObject Panel;
    public GameObject sampleButtonPrefab;
    private int inventoryMax = 7;
    // Start is called before the first frame update
    void Start()
    {
        //Create a sample inventory a player might have
        Item[] playerInventory = new Item[inventoryMax]; 
        playerInventory[0] = new Item("Green Potion", beginningImageString + "green_potion", 1);
        playerInventory[1] = new Item("Purple Potion", beginningImageString + "red_potion", 3);
        playerInventory[2] = new Item("Branch", beginningImageString + "branch", 4);
        drawInventory(playerInventory);
    }

    //drawInventory will take a list that represents the player's inventory
    // and draws it along with each item's number on inventory scrollbar
    public void drawInventory(Item[] playerInventory) {
        foreach (Item playerItem in playerInventory) {
            //Create a button for the item and set the parent
            GameObject button = Instantiate(sampleButtonPrefab);
            button.transform.SetParent(Panel.transform);
            if (!(playerItem.itemName == null))
            {
                //Change the child image of the button to image of the item if playerItem is not empty
                Image imageToChange = button.transform.GetChild(0).GetComponent<Image>();
                //by default, the alpha (transparency) is set to 0 so empty objects in inventory have a red square in their place. 
                //if this is a non-empty object, we want to change that so the image can be seen again
                var tempColor = imageToChange.color;
                tempColor.a = 1f;
                imageToChange.color = tempColor;
                imageToChange.sprite = Resources.Load<Sprite>(playerItem.getImageName());
                //Change the child text of the button to the number of items
                Text numItems = button.transform.GetChild(1).GetComponent<Text>();
                numItems.text = "" + playerItem.getQuantity();

            }      
        }
    }
}
