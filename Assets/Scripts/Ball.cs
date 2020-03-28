using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    bool started = false; // false по умолчанию
    bool sticky;
    Platform platform;
    Rigidbody2D rb;
    Vector3 ballOffset;

    public bool IsStarted()
    {
        return started;
    }
    public void MadeSticky()
    {
        sticky = true;
    }
    public void ModifySpeed(float modificator)
    {
        rb.velocity = rb.velocity * modificator;
    }
    public void ModifiScaleBall(float scale)
    {

    }
    public void ModifiScalePlatform()
    {

    }
    //public void Duplicate(
    //Ball newBall = Instantiate(this);
    //newBall = this; 
    //)
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        platform = FindObjectOfType<Platform>(); // находит геймОбжек Platform
        rb = GetComponent<Rigidbody2D>(); // найти компонент Rigidbody2D в том же геймОбжект, где находится скрипт
        ballOffset = transform.position - platform.transform.position; //вектор между платформой и мячом
        Debug.Log(ballOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            LockBallToPlatform();
        }
    }
    public void StopBall()
    {
        platform = FindObjectOfType<Platform>();
        transform.position = new Vector3(platform.transform.position.x, transform.position.y + 2, 0);
        started = false;
        rb.velocity = Vector2.zero;
    }
    public void LockBallToPlatform()
    {   
        // transform.position = new Vector3(platform.transform.position.x, transform.position.y, 0); // мяч привязан к позиции платформы по х
        transform.position = platform.transform.position + ballOffset;
        if (Input.GetMouseButtonDown(0)) // ели нажата ЛКМ, то запуск мяча
        {
            LaunchBall();
        }
    }
    public void LaunchBall()
    {
        started = true;
        int way = Random.Range(0, 2) * 2 - 1;
        float rand = Random.Range(0, speed) * way;
        Vector2 force = new Vector2(way * (speed - rand), (speed + rand));
        rb.AddForce(force);

    }
    void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.color = Color.yellow;
            //Vector3 to = (Vector2)transform.position + rb.
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.velocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if (sticky)
            {
                started = false;
                rb.velocity = Vector2.zero; // y==0 and x==0 
                ballOffset = transform.position - platform.transform.position; //вектор между платвормой и мячом
            }
        }
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

