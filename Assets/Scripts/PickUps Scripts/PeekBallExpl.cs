using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeekBallExpl : PickUpBallPoints
{
    private Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    public override void ApplyPickUp()
    {
        ball.isExploding = true;
    }
}