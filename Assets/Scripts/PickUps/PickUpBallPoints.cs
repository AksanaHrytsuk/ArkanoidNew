using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallPoints : MonoBehaviour
{
    Points points;
    public int pointsAmount;
    // Start is called before the first frame update
    void Start()
    {
      points = FindObjectOfType<Points>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Platform")
        {
            //Debug.Log("i'm here");
            points.countPoints(pointsAmount);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "LoseGame")
        {
            Destroy(gameObject);
        }
    }
}
