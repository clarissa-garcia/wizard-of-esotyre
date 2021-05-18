using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    public string sceneName;

    public Door()
    {
        showFloatingText = false;
        showPopUp = true;
    }

    protected override void Interact()
    {
        if (IsHovered() && Input.GetKeyDown("e"))
        {
            Debug.Log("Player interacted with " + name);
            SceneManager.LoadScene(sceneName);
        }
    }

}
