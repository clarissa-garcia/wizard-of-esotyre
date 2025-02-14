using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    private static Dictionary<Item, int> items = new Dictionary<Item, int>(7); // Dictionary with <Item, number in players inventory>. 
    public static Sprite[] itemSprites =  Resources.LoadAll<Sprite>("ItemIcons");

    private static List<string> itemNames = new List<string>{
            "Red Potion",
            "Green Potion",
            "Wood",
            "Water",
            "Coffee Gounds",
            "Coffee",
            "Wand of Repair",
            "Boots",
            "Jumping Boots",
            "Potion of Destruction",
            "Black Powder",
            "Focusing Crystal",
            "Gem of Power",
            "Chili",
            "Metal Block",
            "Holy Fire"
        };

    private static List<int> itemSpriteID = new List<int>{
        104,
        102,
        228,
        250,
        209,
        212,
        72,
        94,
        95,
        105,
        259,
        240,
        73,
        165,
        193,
        229,
        9
    };

    private static bool genDemoInventory = false; 
    private static bool genStartInventory = true; 
    

    public static Dictionary<Item, int> GetAll()
    {
        return items;
    }

    public static int Count()
    {
        return items.Count;
    }
    
    /// <summary>
    /// Attempts to remove an item from the players inventory. 
    /// </summary>
    /// <param name="item"> Item to remove </param>
    /// <returns> The item if successfully removed, null if the item is not in the players inventory. </returns>
    public static Item RemoveItem(Item item)
    {
        if (ContainsItem(item) != null)
        {
            item = ContainsItem(item);

            if (--items[item] == 0)
                items.Remove(item);

            return item;
        }
        else
            return null;
    }  


    /// <summary>
    /// Attempts to add 1 item to the players inventory if there is room. 
    /// </summary>
    /// <param name="item"> Item to add to the inventory </param>
    /// <returns> The new item amount in the players inventory, 0 if there's no space to add the item. </returns>
    public static int AddItem(Item item)
    {
        Debug.Log("Adding item");
        return AddItem(item, 1);
    }

    public static int AddItem(Item item, int n)
    {
        if (items.Count > 7) // no room in inventory 
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

    public static void GenDemoInventory()
    {
        if (genDemoInventory)
        {
            AddItem(new Item("Coffee", itemSprites[212]));
            AddItem(new Item("Black Powder", itemSprites[259]));
            AddItem(new Item("Holy Fire", itemSprites[9]));
            AddItem(new Item("Chili", itemSprites[193]));
            AddItem(new Item("Gem of Power", itemSprites[165]));
            AddItem(new Item("Wand of Repair", itemSprites[72]));

            genDemoInventory = false; 
        }

        if(genStartInventory){
            genStartInventory = false; 
            AddItem(CreateItem(4));
        }
            
    }

    public static int getItemCount(Item item) {
        int value;
        if (items.TryGetValue(item, out value)){
            return value;
        }
        return 0;
    }

    private static Item ContainsItem(Item item)
    {
        foreach(KeyValuePair<Item, int> entry in items)
        {
            if (entry.Key.name == item.name)
                return entry.Key; 
        }

        return null; 
    }

    public static Item CreateItem(int ID){
        return new Item(itemNames[ID], itemSprites[itemSpriteID[ID]]);
    }
}
