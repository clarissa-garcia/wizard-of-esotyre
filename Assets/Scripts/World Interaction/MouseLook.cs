using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float raycastDist = 10; // max distance of teh raycast 

    private InteractableObject currentHover; 

    float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHover = null;
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    private void FixedUpdate()
    {
        RaycastInteractables(); // Raycast to find interactables
    }

    /// <summary>
    /// Raycasts from the camera to detect interactable objects in 3D space. 
    /// </summary>
    private void RaycastInteractables()
    {
        RaycastHit hit; // stores data of the object hit
        Vector3 fwd = transform.TransformDirection(Vector3.forward); // get the angle we'll be shootin' from

        int layerMask = 1 << 3; // Filter only things that are in the interactable layer.

        // Shoot out that raycast *pew* *pew*
        if (Physics.Raycast(transform.position, fwd, out hit, raycastDist, layerMask, QueryTriggerInteraction.Collide))
        {
            // Get the interactable object from the hit object
            InteractableObject interactable = hit.collider.gameObject.GetComponent<InteractableObject>();

            // Hovering over a new object
            if (interactable != currentHover)
            {
                if (currentHover) currentHover.HoverExit(); // old hover is not null
                                                            // then disable it's outline
                currentHover = interactable;                // update the new current object being hovered over
                currentHover.HoverEnter();                  // Outline the new object
            }
        }
        // The raycast didn't collide with anything
        else
        {  
            // Update info if we were hitting something last frame
            if (currentHover)
            {
                currentHover.HoverExit(); 
                currentHover = null;
            }
                
        }
    }
}


