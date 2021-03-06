﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Platform platform;
    Rigidbody2D rb;
    private AudioSource _audio;
    Vector3 ballOffset;

    [Header("Config Elements")]    
    public float speed;
    public float maxScale = 2f;
    public float minScale = 0.5f;
    public bool isExploding;
    public float explodeRadius;
    bool started; // false по умолчанию
    bool sticky;
    
    public void ExploudBall()
    {
        if (isExploding)
        {
            //explode

            //layer mask to filter physics objects
            LayerMask layerMask = LayerMask.GetMask($"Block");

            //find objects in radius
            Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);


            foreach (Collider2D objectI in objectsInRadius)
            {
                if (objectI.gameObject == gameObject)
                {
                    continue; //the same gameObject ==> next iteration
                }

                Block block = objectI.gameObject.GetComponent<Block>();
                if (block == null)
                {
                    Destroy(objectI.gameObject);
                }
                else
                {
                    block.DestroyBlock();
                }
            }
        }
    }

    public bool IsStarted()
    {
        return started;
    }

    public void MadeSticky()
    {
        sticky = true;
    }

    private void Awake()
    {
        started = false;

        rb = GetComponent<Rigidbody2D>(); //Найти компонент Rigidbody2D на том же гейм обжекте
        _audio = GetComponent<AudioSource>();

    }

    public void ModifySpeed(float modificator)
    {
        rb.velocity = rb.velocity * modificator;
    }

    public void ModifiScaleBall(float scale)
    {
        if (transform.localScale.x < maxScale && transform.localScale.y < maxScale )
        {
            if (transform.localScale.x > minScale && transform.localScale.y > minScale)
            {
                transform.localScale *= scale;
            }
        }
    }

    public void Duplicate()
    {
        Ball newBall = Instantiate(this);
        newBall.started = true;
        newBall.LaunchBall();
        if (sticky)
        {
            newBall.MadeSticky();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        platform = FindObjectOfType<Platform>(); // находит геймОбжек Platform
        rb = GetComponent<Rigidbody2D>(); // найти компонент Rigidbody2D в том же геймОбжект, где находится скрипт
        ballOffset = transform.position - platform.transform.position; //вектор между платформой и мячом
        //Debug.Log(ballOffset);
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
        transform.position = new Vector3(platform.transform.position.x, transform.position.y, 0);
        started = false;
        rb.velocity = Vector2.zero;
    }

    private void LockBallToPlatform()
    {
        if (!sticky)
        {
            transform.position =
                new Vector3(platform.transform.position.x, platform.transform.position.y + 1,
                    0); // мяч привязан к позиции платформы по х
        }
        else
        {
            transform.position = platform.transform.position + ballOffset;
        }
        if (Input.GetMouseButtonDown(0)) // ели нажата ЛКМ, то запуск мяча
        {
            LaunchBall();
        }
    }

    public void LaunchBall()
    {
        started = true;
        int way = Random.Range(0, 2) * 2 - 1;
        
        // float rand = Random.Range(0, speed) * way;
        // Vector2 force = new Vector2(way * (speed - rand), (speed + rand)); рандомный угол наклона мяча при запуске
        Vector2 force = new Vector2(way * speed, speed);
        rb.AddForce(force);
    }

    void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.color = Color.yellow;
            //Vector3 to = (Vector2)transform.position + rb.
            Gizmos.DrawLine(transform.position, transform.position + (Vector3) rb.velocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio.Play();
        //_audio.Stop(); switch off sound
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (sticky)
            {
                started = false;
                rb.velocity = Vector2.zero;

                ballOffset = transform.position - platform.transform.position; //вектор между платвормой и мячом
            }
        }
        
        if (collision.gameObject.CompareTag($"Block"))
        {
            Debug.Log("Взрыв мяча!");
            ExploudBall();
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