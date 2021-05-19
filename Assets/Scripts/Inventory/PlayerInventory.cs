using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Inventory System/Player Inventory", fileName = "PlayerInventory.asset")]
public class PlayerInventory : Inventory{
    static PlayerInventory _instance = null;
    public static PlayerInventory Instance
    {
        get
        {
            if (!_instance){
                PlayerInventory[] tmp = Resources.FindObjectsOfTypeAll<PlayerInventory>();
                if(tmp.Length > 0){
                    _instance = tmp[0];
                }
            }
            
            return _instance;
        }
    }
}