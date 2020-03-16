using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallScript : MonoBehaviour
{
    int hearts;
    Ball ball;
    LoaderScens loaderScens;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        loaderScens = FindObjectOfType<LoaderScens>();
        hearts++;
        ball = FindObjectOfType<Ball>();
        ball.StopBall(); 
        //Debug.Log("CollisionEnterWall");
        if (hearts >= 3)
        {
            loaderScens.LoadNextSceneByName("Game Over");
        }
    }
}
