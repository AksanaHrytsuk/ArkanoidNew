using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScens : MonoBehaviour
{
   public void LoadNextScene(){
    //   SceneManager.LoadScene(sceneName);
   int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
   SceneManager.LoadScene(activeSceneIndex + 1);
   }
   public void exitGame(){
       Application.Quit();
   }


}

