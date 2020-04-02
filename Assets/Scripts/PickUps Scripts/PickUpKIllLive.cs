using UnityEngine;


public class PickUpKIllLive : PickUpBallPoints
{
    Points points;

    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
    }

    public override void ApplyPickUp()
    {
        points.BallDown();
    }
}