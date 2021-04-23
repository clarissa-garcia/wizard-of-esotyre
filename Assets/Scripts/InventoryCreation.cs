using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCreation : MonoBehaviour
{
    private string beginningImageString = "Sprites/";
    public GameObject Panel;
    public GameObject sampleButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Create a sample inventory a player might have
        List<Item> playerInventory = new List<Item>();
        playerInventory.Add(new Item("Green Potion", beginningImageString + "green_potion", 1));
        playerInventory.Add(new Item("Purple Potion", beginningImageString + "red_potion", 3));
        playerInventory.Add(new Item("Branch", beginningImageString + "branch", 4));

        drawInventory(playerInventory);
    }

    //drawInventory will take a list that represents the player's inventory
    // and draws it along with each item's number on inventory scrollbar
    public void drawInventory(List<Item> playerInventory) {
        foreach (Item playerItem in playerInventory) {
            //Create a button for the item and set the parent
            GameObject button = Instantiate(sampleButtonPrefab);
            button.transform.SetParent(Panel.transform);
            //Change the child image of the button to image of the item
            Image imageToChange = button.transform.GetChild(0).GetComponent<Image>();
            imageToChange.sprite = Resources.Load<Sprite> (playerItem.getImageName());
            //Change the child text of the button to the number of items
            Text numItems = button.transform.GetChild(1).GetComponent<Text>();
            numItems.text = ""+playerItem.getQuantity();
        }
    }
}
