using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{

    public GameObject floatingTextObject;
    public bool showFloatingText = true;
    [TextArea(5, 10)]
    public string floatingText;
    [Tooltip("Shows pop up when player hovers over")]
    public bool showPopUp = false;
    [TextArea(5, 10)]
    public string popUpText;
    

    private cakeslice.Outline outln; // outline attached to object
    private GameObject mainCamera = null;
    private MouseLook playerHUD;
    

    private void Start()
    {
        gameObject.layer = 3;
        outln = gameObject.AddComponent<cakeslice.Outline>();
        mainCamera = null;
        mainCamera = GameObject.FindWithTag("FPCamera");
        if(mainCamera) 
            playerHUD = mainCamera.GetComponent<MouseLook>();
        outln.enabled = false;
        if(popUpText == "")
            popUpText = "Pop up text here";
        if (floatingText == "")
            floatingText = "Float text here";
        if (showFloatingText)
            floatingTextObject.GetComponent<TextMeshPro>().text = floatingText;
    }

    void Update()
    {
        if (showFloatingText)
            floatingTextObject.transform.rotation = Quaternion.LookRotation(floatingTextObject.transform.position - mainCamera.transform.position);

        Interact();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Entered");
        outln.enabled = true;
        /*if (showPopUp)
            playerHUD.ShowPopUp(popUpText);*/
    }

    private void OnMouseExit()
    {
        outln.enabled = false;
        /*if (showPopUp)
            playerHUD.HidePopUp();*/
    }

    virtual protected void Interact()
    {
        if (IsHovered() && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player interacted with " + name);
        }
    }

    protected bool IsHovered()
    {
        return outln.enabled;
    }
}
