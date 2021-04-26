using System;
using System.Collections.Generic;

public class Item_Map
{
    public Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    public Item GetItem(string itemSpriteName)
    {
        // Get the result from the static Dictionary.
        Item result;
        if (itemDictionary.TryGetValue(itemSpriteName, out result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public void AddMapItem(string spriteName, Item playerItem)
    {
        itemDictionary.Add(spriteName, playerItem);
    }
}