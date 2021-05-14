using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecipeController
{

    public static RecipeNode head = new RecipeNode();
    private static bool genDemoTree = false;
    public static Sprite[] itemSprites =  Resources.LoadAll<Sprite>("ItemIcons");
    public static RecipeNode current;

    public static void GenDemoTree()
    {
        if (!genDemoTree)
        {
            RecipeNode current = head.AddChild(new Item("Water", itemSprites[250]));
            current = current.AddChild(new Item("Coffee Beans", itemSprites[209]));
            current.SetFinalStir(true, 2);
            current.SetResult(new Item("Coffee", itemSprites[212]));

            genDemoTree = true;
        }
        current = head;
    }

    public static Item CheckRecipe(Dictionary<Item, int> items, bool clockwise, int numStirs)
    {
        GenDemoTree();
        RecipeNode currentNode = head;
        foreach (KeyValuePair<Item, int> item in items)
        {
            Debug.Log(item.Key.name);
            if (currentNode.HasChild(item.Key))
            {
                currentNode = currentNode.GetChild(item.Key);
                Debug.Log("Has Child");
            }
            else
            {
                return null;
            }
        }
        Debug.Log(clockwise + ", " + numStirs);
        if (currentNode.IsFinalStir(clockwise, numStirs))
        {
            Debug.Log("Valid Recipe");
            return currentNode.GetResult();
        }
        else
        {
            return null;
        }
    }

    public static Item CheckEnchant(Dictionary<Item, int> items, string enchantment)
    {
        GenDemoTree();
        RecipeNode currentNode = head;
    }
}
