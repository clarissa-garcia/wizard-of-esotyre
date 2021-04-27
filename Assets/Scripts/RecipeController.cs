using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecipeController
{

    public static RecipeNode head = new RecipeNode();
    private static bool genDemoTree = false;
    public static Sprite[] itemSprites =  Resources.LoadAll<Sprite>("ItemIcons");

    public static void GenDemoTree()
    {
        if (!genDemoTree)
        {
            RecipeNode current = head.AddChild(new Item("Water", itemSprites[250]));
            current.AddChild(new Item("Coffee Beans", itemSprites[209]));
            current.SetFinalStir(false, 2);
            genDemoTree = true;
        }
    }

    public static Item CheckRecipe(Dictionary<Item, int> items, bool clockwise, int numStirs)
    {
        RecipeNode currentNode = head;
        foreach (KeyValuePair<Item, int> item in items)
        {
            if (currentNode.HasChild(item.Key))
            {
                currentNode = currentNode.GetChild(item.Key);
            }
            else
            {
                return null;
            }
        }

        if (currentNode.IsFinalStir(clockwise, numStirs))
        {
            return currentNode.GetResult();
        }
        else
        {
            return null;
        }
    }
}
