using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.

public class DontDestroy : MonoBehaviour
{
    public Canvas inventoryCanvas;
    void Awake()
    {
        DontDestroyOnLoad(inventoryCanvas);
    }
}