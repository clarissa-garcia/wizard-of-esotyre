using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecipeController
{

    public static RecipeNode head = new RecipeNode();
    private static bool genDemoTree = false;
    public static Sprite[] itemSprites =  Resources.LoadAll<Sprite>("ItemIcons");
    public static RecipeNode current;
    public static GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    public static void GenDemoTree()
    {
        if (!genDemoTree)
        {
            RecipeNode current = head.AddChild(new Item("Water", itemSprites[250]));
            current = current.AddChild(new Item("Coffee Beans", itemSprites[209]));
            current.SetFinalStir(true, 2);
            current.SetResult(new Item("Coffee", itemSprites[212]));
            current.SetOutsideChange(1);

            current = head.AddChild(new Item("Wood", itemSprites[228]));
            current = current.AddChild(new Item("Focusing Crystal", itemSprites[240]));
            current.SetFinalEnchant("Ren Phe Tah");
            current.SetResult(new Item("Wand of Repair", itemSprites[72]));

            current = head.AddChild(new Item("Boots", itemSprites[94]));
            current = current.AddChild(new Item("Metal Block", itemSprites[229]));
            current.SetFinalEnchant("Hed Lig Phe");
            current.SetResult(new Item("Jumping Boots", itemSprites[72]));

            current = head.AddChild(new Item("Coffee", itemSprites[212]));
            current = current.AddChild(new Item("Black Powder", itemSprites[259]));
            current = current.AddChild(new Item("Holy Fire", itemSprites[9]));
            current = current.AddChild(new Item("Chili", itemSprites[193]));
            current.SetFinalStir(false, 4);
            current.SetResult(new Item("Potion of Destruction", itemSprites[105]));

            current = head.AddChild(new Item("Potion of Destruction", itemSprites[105]));
            current = head.AddChild(new Item("Wand of Repair", itemSprites[72]));
            current = head.AddChild(new Item("Gem of Power", itemSprites[165]));
            current.SetFinalEnchant("Mul Rut Cha");
            current.SetResult(new Item("Wand of Destruction", itemSprites[73]));


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
        Debug.Log(enchantment);
        if (currentNode.IsFinalEnchant(enchantment))
        {
            Debug.Log("Valid Recipe");
            return currentNode.GetResult();
        }
        else
        {
            return null;
        }
    }

    public static void PerformOutsideChange(int i)
    {
        switch(i)
        {
            case 1:
                manager.repair = true;
                break;
            case 2:
                manager.jumpBoost = true;
                break;
            case 3:
                manager.repair = false;
                manager.destroy = true;
                break;
            default:
                break;
        }
    }
}
