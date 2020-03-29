using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    public int addPoints;
    WallDownScript wallDownScripts;
    int hearts;
    Ball ball;
    public int maxHearts;

    LoaderScens loaderScens;

    // Start is called before the first frame update
    private void Awake()
    {
        Points[] pointsList = FindObjectsOfType<Points>();
        Debug.Log(pointsList.Length);
        if (pointsList.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ballDown()
    {
        loaderScens = FindObjectOfType<LoaderScens>();
        hearts++;
        ball = FindObjectOfType<Ball>();
        ball.StopBall();
        //Debug.Log("CollisionEnterWall");
        if (hearts >= maxHearts)
        {
            loaderScens.LoadNextSceneByName("Game Over");
        }
    }

    public void countPoints(int score)
    {
        addPoints += score;
        points.text = "Points: " + addPoints;
        DontDestroyOnLoad(gameObject);
    }
}