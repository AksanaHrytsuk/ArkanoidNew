using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
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
        
        ball = FindObjectOfType<Ball>();
        Platform platform = FindObjectOfType<Platform>();
        ball.transform.position = new Vector3(platform.transform.position.x, transform.position.y + 2, 0);
        ball.LockBallTOPlatform(); 
        Debug.Log("CollisionEnterWall");
    }

}
