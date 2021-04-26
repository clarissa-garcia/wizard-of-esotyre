using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float raycastDist = 5; // max distance of the raycast 
    public GameObject popUp;
    public TextMeshProUGUI popUpText;

    public List<Sprite> buttonIcons = new List<Sprite>(); 

    float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
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
    

    public void ShowPopUp(string text)
    {
        popUp.SetActive(true);
        popUpText.text = text;
    }

    public void HidePopUp()
    {
        popUp.SetActive(false);
    }
}


