using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject playerInventoryCanvas;
    public string nextScene;

    //clickButton function needs to be here. a void function is required
    //to be a button function
    public void clickButton() {
        StartCoroutine(LoadYourAsyncScene(nextScene));
    }
    public IEnumerator LoadYourAsyncScene(string nextScene)
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(""+nextScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(playerInventoryCanvas, SceneManager.GetSceneByName(""+nextScene));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}