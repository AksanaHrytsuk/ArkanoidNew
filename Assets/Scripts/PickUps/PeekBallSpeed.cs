using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeekBallSpeed : MonoBehaviour
{
    public float speedKoeff;
    void ApplyEffect()
    {
        Debug.Log("Change ball speed");
        Ball ball = FindObjectOfType<Ball>();
        ball.ModifySpeed(speedKoeff);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pickup trigger! " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("much faster");
            ApplyEffect();
            Destroy(gameObject);
        }
        /* else if (collision.gameObject.tag == "LoseGame")
        {
            Destroy(gameObject);
            Debug.Log("PickUp is crashed");
        } */
    }
    //dosmt
}
