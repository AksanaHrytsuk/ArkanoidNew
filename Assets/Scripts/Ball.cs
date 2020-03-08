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
        platform = FindObjectOfType<Platform>(); // находит геймОбжек Platform
        rb = GetComponent<Rigidbody2D>(); // найти компонент Rigidbody2D в том же геймОбжект, где находится скрипт
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
    private void LockBallTOPlatform()
    {
        // ldbufnmcz lfkmit
        transform.position = new Vector3(platform.transform.position.x, transform.position.y, 0);
        // мяч привязан к позиции платвормы по х
        if (Input.GetMouseButtonDown(0)) // ели нажата ЛКМ, то запуск мяча
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

    // Вызов событий у движка физики. 
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

}

