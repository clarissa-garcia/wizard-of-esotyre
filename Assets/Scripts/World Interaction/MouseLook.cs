using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
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
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 3;
        if (Physics.Raycast(transform.position, fwd, out hit,10, layerMask, QueryTriggerInteraction.Collide))
        {   
            
            GameObject collidedObj = hit.collider.gameObject;
            InteractableObject interactable = collidedObj.GetComponent<InteractableObject>();

            if (interactable != currentHover)
            {
                if (currentHover)
                    currentHover.HoverExit();
                currentHover = interactable;
                currentHover.HoverEnter();
            }
        }
        else
        {
            if (currentHover)
                currentHover.HoverExit();
            currentHover = null;
        }
    }
}
