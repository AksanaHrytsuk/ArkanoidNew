﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public Sprite[] images;
    public int hitPoint;
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
        hitPoint++;
        if (hitPoint < 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = images[hitPoint - 1];
        }
        //Debug.Log(hitPoint);
        else
        {
            Destroy(gameObject);
            Points.countPoints++;
            Debug.Log(Points.countPoints);
        }
        //Debug.Log("CollisionExit");

    }
}
