using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [Header("UI Elements")]
    public Text points;
    public Text text;
    
    [Header("Config parametrs")]
    public int addPoints;
    public int maxHearts;
    int hearts;
    
    WallDownScript wallDownScripts;
    Ball ball;
    
    LoaderScens loaderScens;
    private void Awake()
    {
        Points[] pointsList = FindObjectsOfType<Points>();
        // Debug.Log(pointsList.Length);
        if (pointsList.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void BallDown()
    {
        loaderScens = FindObjectOfType<LoaderScens>();
        maxHearts--;
        ball = FindObjectOfType<Ball>();
        ball.StopBall();
        text.text = "Lives: " + maxHearts;
        //Debug.Log("CollisionEnterWall");
        if (maxHearts == 0)
        {
            loaderScens.LoadNextSceneByName("Game Over");
        }
    }

    public void countPoints(int score)
    {
        text.text = "Lives: " + maxHearts;
        addPoints += score;
        points.text = "Points: " + addPoints;
    }
}