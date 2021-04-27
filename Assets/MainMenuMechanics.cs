using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMechanics : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Quiting");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Esotyre");
    }

}
