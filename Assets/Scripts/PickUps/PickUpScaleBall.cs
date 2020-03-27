using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScaleBall : MonoBehaviour
{
    public float changeScale;
    Ball ball;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ball = FindObjectOfType<Ball>();
            ball.ModifiScaleBall(changeScale);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "LoseGame")
        {
            Destroy(gameObject);
        }
    }
}
