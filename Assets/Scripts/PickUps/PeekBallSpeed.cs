using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeekBallSpeed : PickUpBallPoints
{
    public float speedKoeff;

    public override void ApplyPickUp()
    {
        Debug.Log("Change ball speed");
        Ball ball = FindObjectOfType<Ball>();
        ball.ModifySpeed(speedKoeff);
    }
}