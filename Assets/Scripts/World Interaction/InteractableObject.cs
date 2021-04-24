using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    cakeslice.Outline outln;

    private void Start()
    {
        outln = GetComponent<cakeslice.Outline>();
        outln.enabled = false;
    }
    public void HoverEnter()
    {
        outln.enabled = true;
    }

    public void HoverExit()
    {
        outln.enabled = false;
    }
}
