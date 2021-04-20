using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
    private string imageName;
    private int quantity;
    //private GameObject physical;

    //public Item(string nameIn, string imageNameIn, int quantityIn, string physicalIn)
    public Item(string nameIn, string imageNameIn, int quantityIn)
    {
        setName(nameIn);
        setImageName(imageNameIn);
        setQuantity(quantityIn);
        //setPhysical(physicalIn);
    }

    public void setName(string nameIn)
    {
        this.itemName = nameIn;
    }

    public string getName() {
        return this.itemName;
    }
    public void setImageName(string imageNameIn)
    {
        this.imageName = imageNameIn;
    }

    public string getImageName(){
        return this.imageName;
}
    public void setQuantity(int quantityIn)
    {
        this.quantity = quantityIn;
    }

    public int getQuantity() {
        return this.quantity;
    }
   /* public void setPhysical(string physicalIn)
    {
        this.physical = physicalIn;
    }*/
}
