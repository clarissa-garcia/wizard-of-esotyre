using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public GameObject playerObject;
    private GameObject cauldronObject;


    public void OnFinishedRecipe() {
        //Fetch the array of items given to the cauldron
        cauldronObject = GameObject.FindWithTag("Cauldron");
        Item[] cauldronArray = cauldronObject.GetComponent<CauldronInventory>().cauldronInventory;
        for (int i = 0; i < cauldronArray.Length; i++) {
        if (cauldronArray[i]!=null)
         Debug.Log(cauldronArray[i].itemName);
        }
        //Add in logic checks from workstation (numbers of stirs, direction, etc)
        //After verifying player's recipe, add new item to inventory
        //Example of created item added: 

        Item tobeAdded = new Item("Candle", "Sprites/candle", 1);
        playerObject.GetComponent<PlayerInventory>().addItem(tobeAdded);
        playerObject.GetComponent<PlayerInventory>().playerMap.AddMapItem("Sprites/candle", tobeAdded);
    }
}
