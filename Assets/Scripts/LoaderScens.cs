using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScens : MonoBehaviour
{
    public void LoadNextScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1, LoadSceneMode.Single);
    }
    public void exitGame()
    {
        Application.Quit();
    }

    public void LoadNextSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    // public void RestartLevel()
    // {
    //     string name = SceneManager.GetActiveScene().name;
    //     SceneManager.LoadScene(name);
    // }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    //public void LoadeLevel()
}

