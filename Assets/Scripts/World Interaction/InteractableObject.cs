using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    private cakeslice.Outline outln; // outline attached to object

    private void Start()
    {
        outln = GetComponent<cakeslice.Outline>();
        outln.enabled = false;
    }

    /// <summary>
    /// Called when crosshair hovers over object. Enables outline on object. 
    /// </summary>
    public void HoverEnter()
    {
        outln.enabled = true;
    }

    /// <summary>
    /// Called when crosshair exits hover over object. Disables outline on object. 
    /// </summary>
    public void HoverExit()
    {
        outln.enabled = false;
    }
}
