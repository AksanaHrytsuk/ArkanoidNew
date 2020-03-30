using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLives : MonoBehaviour
{
    Points points;
    int livesAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Platform"))
        {
            //Debug.Log("i'm here");
            points.maxHearts += livesAmount;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LoseGame"))
        {
            Destroy(gameObject);
        }
    }
}
