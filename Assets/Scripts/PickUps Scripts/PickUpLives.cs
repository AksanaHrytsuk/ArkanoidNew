using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLives : PickUpBallPoints
{
    Points points;

    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
    }

    public override void ApplyPickUp()
    {
        points.maxHearts++;
    }
}