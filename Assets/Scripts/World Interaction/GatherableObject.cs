using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableObject : InteractableObject
{
    // Start is called before the first frame update
    public bool unlimited;
    
    [Tooltip("Item this will generate when player interacts")]
    public Item item; 

    protected override void Start() {
        base.Start();
        //floatingText = Inventory.CreateItem(ID).name;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnMouseDown() {
        PlayerInventory.Instance.AddItem(item);
        playerHUD.DrawInventory();
    }

}
