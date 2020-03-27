using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallDownScript : MonoBehaviour
{
    public Points points;
    private void Start()
    {
        points = FindObjectOfType<Points>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log(collision.gameObject.name);
            points.ballDown();
        }
       else 
       {
           Destroy(collision.gameObject);
       }
    }
}
