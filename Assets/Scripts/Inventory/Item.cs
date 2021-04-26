using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    private Sprite sprite;
    //private GameObject physical;

    //public Item(string nameIn, string imageNameIn, int quantityIn, string physicalIn)
    public Item(string nameIn, Sprite imageNameIn)
    {
        this.name = nameIn;
        this.sprite = imageNameIn;
    }

    public void SetName(string nameIn)
    {
        this.name = nameIn;
    }

    public string GetName() {
        return this.name;
    }
    public void SetSprite(Sprite imageNameIn)
    {
        this.sprite = imageNameIn;
    }

    public Sprite GetSprite(){
        return this.sprite;
    }


}
