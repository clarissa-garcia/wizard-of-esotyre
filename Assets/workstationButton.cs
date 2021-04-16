using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class workstationButton : MonoBehaviour
{
    public GameObject playerobject;
    public void ClickedItem()
    {
        //Check that the button clicked has an image (is a non-empty item)
        // Then use the image name to look up the player's inventory item to update the quantity
        // in code and on the screen
        Image imageToChange = transform.GetChild(0).GetComponent<Image>();
        if (imageToChange.sprite.name != null)
        {
            playerobject = GameObject.FindWithTag("Player");
            Item_Map playerMap = playerobject.GetComponent<Item_Map>();
            playerMap.itemDictionary.TryGetValue(imageToChange.sprite.name, out Item value);
            value.setQuantity(value.getQuantity() - 1);

            // Paint new value on the inventory screen
            Text numItems = transform.GetChild(1).GetComponent<Text>();
            numItems.text = "" + value.getQuantity();
        }
    }
}
