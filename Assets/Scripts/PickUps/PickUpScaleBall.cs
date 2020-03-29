using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScaleBall : MonoBehaviour
{
    public float changeScale;
    Ball ball;
    // Start is called before the first frame update
    private void ApplyAffect()
    {
        Ball[] ball = FindObjectsOfType<Ball>();
        for (int i = 0; i > ball.Length; i++)
        {
            ball[i].ModifiScaleBall(changeScale);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyAffect();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LoseGame"))
        {
            Destroy(gameObject);
        }
    }
}
