using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CauldronInventory
{
    private static List<Item> items = new List<Item>(); // Dictionary with <Item, number in cauldron>. 

    public static List<Item> GetAll()
    {
        List<Item> result = items;
        items = new List<Item>();
        return result;
    }

    public static void AddItem(Item item)
    {
        AddItem(item, 1);
    }

    public static void AddItem(Item item, int n)
    {
        if (!ContainsItem(item)) {
            items.Add(item);
        }
        return;
    }

    private static bool ContainsItem(Item item)
    {
        foreach (Item entry in items)
        {
            if (entry.name == item.name)
                return true;
        }

        return false;
    }
}
