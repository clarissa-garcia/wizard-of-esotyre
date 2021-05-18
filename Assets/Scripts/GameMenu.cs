using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public AudioClip TitleMusic;
    public AudioClip MouseClick;

    public HUD playerHUD; 

    public void Start()
    {
        SoundManager.Instance.PlayMusic(TitleMusic);
    }

    public void ExitButton()
    {
        SoundManager.Instance.Play(MouseClick);
        Application.Quit();
        Debug.Log("Game Quiting");
    }

    public void StartGame()
    {
        SoundManager.Instance.Play(MouseClick);
        SceneManager.LoadScene("Esotyre");
    }

    public void ResumeGame()
    {
        SoundManager.Instance.Play(MouseClick);
        playerHUD.ResumeGame();
    }
}
