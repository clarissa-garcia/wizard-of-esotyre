using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI itemCount;
    public Image itemCountBG;
    public Image itemIcon;
    public Item itemHeld;

    public void SetItemIcon(Sprite sprite)
    {
        SetImageAlpha(itemIcon, 1);
        itemIcon.sprite = sprite; 
    }

    public void SetIconAndCount(Sprite sprite, int n)
    {
        SetItemIcon(sprite);
        UpdateItemCount(n);
    }

    public void UpdateItemCount(int n)
    {
        if(n == 0)
            ClearSlot();
        else
        {
            itemCount.enabled = true;
            SetImageAlpha(itemCountBG, 1);
            itemCount.text = n.ToString();
        }

    }

    public void ClearSlot()
    {
        SetImageAlpha(itemIcon, 0);
        SetImageAlpha(itemCountBG, 0);
        itemCount.enabled = false;
    }

    public static void SetImageAlpha(Image img, float n)
    {
        Color tmp = img.color;
        tmp.a = n;
        img.color = tmp; 
    }

    public void setItem(Item itemSlotItem) {
        this.itemHeld = itemSlotItem;
    }
}
