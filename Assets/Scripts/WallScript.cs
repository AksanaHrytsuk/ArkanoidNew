using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallScript : MonoBehaviour
{
    int hearts;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hearts++;
        ball = FindObjectOfType<Ball>();
        ball.StopBall(); 
        //Debug.Log("CollisionEnterWall");
        if (hearts >= 3)
        {
            RestartLevel();
        }
    }
    
    public void RestartLevel()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
}
