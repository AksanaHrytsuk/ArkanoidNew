using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallDownScript : MonoBehaviour
{
    Points points;
    private void Start()
    {
        points = FindObjectOfType<Points>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (FindObjectsOfType<Ball>().Length == 1)
            {
                points.ballDown();
            }
            else
            {
                Destroy(collision.gameObject);
            }
            //Debug.Log(collision.gameObject.name);
        }
        else 
        {
            Destroy(collision.gameObject);
        }
    }
}
