using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int speed;
    bool started; // false по умолчанию
    public Platform platform;
    Rigidbody2D rb;
   
    public bool IsStarted()
    {
        return started;
    }

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
            // ничего не делает
        }
        else
        {
            LockBallTOPlatform();
        }

    }
    public void StopBall() 
    {
        Platform platform = FindObjectOfType<Platform>();
        transform.position = new Vector3(platform.transform.position.x, transform.position.y + 2, 0);
        started = false;
        rb.velocity = Vector2.zero;
    }
    public void LockBallTOPlatform()
    {
        transform.position = new Vector3(platform.transform.position.x, transform.position.y, 0); // мяч привязан к позиции платформы по х
        if (Input.GetMouseButtonDown(0)) // ели нажата ЛКМ, то запуск мяча
        {
            started = true;
            LaunchBall();
        }
    }
    public void LaunchBall()
    {
        int way = Random.Range(0, 2) * 2 - 1;
        int rand = Random.Range(0, speed) * way;
        Vector2 force = new Vector2(way * (speed - rand), (speed + rand));
        rb.AddForce(force);
    }

    /* Вызов событий у движка физики. 
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
    }*/

}

