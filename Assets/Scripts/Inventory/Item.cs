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

    public override bool Equals(object obj)
    {
        if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Item other = obj as Item;
            return this.name == other.name;
        }
    }

    public override int GetHashCode()
    {
        int hashSum = 0;
        foreach (char c in name)
        {
            hashSum += System.Convert.ToInt32(c);
        }
        return hashSum;
    }


}
