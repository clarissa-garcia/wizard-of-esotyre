using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWand : InteractableObject
{
    // Start is called before the first frame update

    public GameObject finImage; 
    private void OnMouseDown() {
        finImage.SetActive(true);
    }
}
