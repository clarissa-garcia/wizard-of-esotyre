using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeNode
{
    Dictionary<Item, RecipeNode> children;
    
    // if stirring generates recipe
    bool finalStir;
    bool clockwise;
    int numStirs;
    Item stirResult;

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
        Debug.Log(this.clockwise + ", " + this.numStirs);
        if (finalStir)
        {
            return (this.clockwise == clockwise && this.numStirs == numStirs);
        }
        return false;
    }

    public Item GetResult()
    {
        return stirResult;
    }

    public void SetResult(Item item)
    {
        stirResult = item;
    }
}
