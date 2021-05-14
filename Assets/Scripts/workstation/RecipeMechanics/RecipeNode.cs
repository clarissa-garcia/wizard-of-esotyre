using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeNode
{
    Dictionary<Item, RecipeNode> children;

    Item itemResult;

    // if stirring generates recipe
    bool finalStir;
    bool clockwise;
    int numStirs;

    // if enchanting generates recipe
    bool finalEnchant;
    string enchantment;

    int outsideChange = 0;

    public RecipeNode()
    {
        children = new Dictionary<Item, RecipeNode>();
        finalStir = false;
    }

    public RecipeNode AddChild(Item item)
    {
        RecipeNode newChild = new RecipeNode();
        children.Add(item, newChild);
        return newChild;
    }

    public RecipeNode GetChild(Item item)
    {
        RecipeNode result;
        children.TryGetValue(item, out result);
        return result;
    }

    public bool HasChild(Item item)
    {
        Debug.Log("LOOKING FOR " + item.name + " IN DICTIONARY OF SIZE " + children.Count);
        foreach (KeyValuePair<Item, RecipeNode> entry in children)
        {
            Debug.Log(entry.Key.name);
            Debug.Log(item.Equals(entry.Key));
        }
        Debug.Log("DONE LISTING");
        return children.ContainsKey(item);
    }

    public void SetFinalStir(bool clockwise, int numStirs)
    {
        finalStir = true;
        this.clockwise = clockwise;
        this.numStirs = numStirs;
    }

    public bool IsFinalStir(bool clockwise, int numStirs)
    {
        if (finalStir)
        {
            return (this.clockwise == clockwise && this.numStirs == numStirs);
        }
        return false;
    }

    public void SetFinalEnchant(string enchantment)
    {
        finalEnchant = true;
        this.enchantment = enchantment;
    }

    public bool IsFinalEnchant(string enchantment)
    {
        if (finalEnchant)
        {
            return (this.enchantment.Equals(enchantment));
        }
        return false;
    }

    public Item GetResult()
    {
        if (outsideChange != 0)
        {
            Debug.Log("Performing Oustide Change");
            RecipeController.PerformOutsideChange(outsideChange);
        }
        return itemResult;
    }

    public void SetResult(Item item)
    {
        itemResult = item;
    }

    public void SetOutsideChange(int i)
    {
        outsideChange = i;
    }
}
