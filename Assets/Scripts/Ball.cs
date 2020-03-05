using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int speed;
    bool started; // false
    Platform platform;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        platform = FindObjectOfType<Platform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            // ничего неделает
        }
        else
        {
            LockBallTOPlatform();
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CollisionExit");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionStay");
    }


    private void LockBallTOPlatform()
    {
        // ldbufnmcz lfkmit
        transform.position = new Vector3(platform.transform.position.x, transform.position.y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            started = true;
            LaunchBall();
        }
    }
    private void LaunchBall()
    {
        Vector2 force = new Vector2(speed, speed);
        rb.AddForce(force);
    }
}

