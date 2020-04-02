using UnityEngine;

namespace PickUps
{
    public class PickUpMultipleBall : PickUpBallPoints
    {
        public int ballsNumber = 2;
        public override void ApplyPickUp()
        {
            Ball[] ball = FindObjectsOfType<Ball>();
            for (int i = 0; i < ball.Length; i++)
            {
                ball[i].Duplicate();
            }
        }
    }
}
