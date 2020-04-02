using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScaleBall : PickUpBallPoints
{
    public float changeScale;
    Ball ball;
   
    public override void ApplyPickUp()
    {
        Ball[] ball = FindObjectsOfType<Ball>();
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].ModifiScaleBall(changeScale);
        }
    }
}
