using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallPoints : MonoBehaviour
{
    Points points;

    public int pointsAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            points = FindObjectOfType<Points>();
            points.CountPoints(pointsAmount);
            ApplyPickUp();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LoseGame"))
        {
            Destroy(gameObject);
        }
    }

    public virtual void ApplyPickUp()
    {
        //dummy
    }
}