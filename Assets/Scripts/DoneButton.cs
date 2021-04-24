using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public GameObject playerObject;

    public void OnFinishedRecipe() {
        //Add in logic checks from workstation (numbers of stirs, direction, etc)
        //After verifying player's recipe, add new item to inventory
        //Example: 
        Item tobeAdded = new Item("Candle", "Sprites/candle", 1);
        playerObject.GetComponent<PlayerInventory>().addItem(tobeAdded);
        playerObject.GetComponent<PlayerInventory>().playerMap.AddMapItem("Sprites/candle", tobeAdded);
    }
}
