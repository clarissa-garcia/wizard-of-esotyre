using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPlayerInventory : MonoBehaviour
{
    public GameObject Panel;
    public GameObject sampleButtonPrefab;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory inventory = playerObject.GetComponent<PlayerInventory>();
        drawInventory(inventory.playerInventory);
    }

    //drawInventory will take a list that represents the player's inventory
    // and draws it along with each item's number on inventory scrollbar
    public void drawInventory(Item[] playerInventory) {
        for (int i = 0; i < playerInventory.Length; i++) { 
            //Create a button for the item and set the parent
            GameObject button = Instantiate(sampleButtonPrefab);
            button.transform.SetParent(Panel.transform);
            if ((playerInventory[i] != null) && (playerInventory[i].itemName != null))
            {
                //Change the child image of the button to image of the item if playerItem is not empty
                Image imageToChange = button.transform.GetChild(0).GetComponent<Image>();
                //by default, the alpha (transparency) is set to 0 so empty objects in inventory have a red square in their place. 
                //if this is a non-empty object, we want to change that so the image can be seen again
                var tempColor = imageToChange.color;
                tempColor.a = 1f;
                imageToChange.color = tempColor;
                imageToChange.sprite = Resources.Load<Sprite>(playerInventory[i].getImageName());
                //Change the child text of the button to the number of items
                Text numItems = button.transform.GetChild(1).GetComponent<Text>();
                numItems.text = "" + playerInventory[i].getQuantity();

            }      
        }
    }
}
