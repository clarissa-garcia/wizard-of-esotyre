using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CauldronInventory
{
    private static Dictionary<Item, int> items = new Dictionary<Item, int>(7); // Dictionary with <Item, number in cauldron>. 
    public static Dictionary<Item, int> GetAll()
    {
        return items;
    }

    public static int AddItem(Item item)
    {
        return AddItem(item, 1);
    }

    public static int AddItem(Item item, int n)
    {
        if (items.Count >= 7) // no room in inventory 
            return 0;
        else if (ContainsItem(item) != null)// item in inventory already
        {
            item = ContainsItem(item);
            items[item] += n;
        }
        else // item not in inventory, add it
            items.Add(item, n);

        return items[item];
    }

    private static Item ContainsItem(Item item)
    {
        foreach (KeyValuePair<Item, int> entry in items)
        {
            if (entry.Key.name == item.name)
                return entry.Key;
        }

        return null;
    }
}
