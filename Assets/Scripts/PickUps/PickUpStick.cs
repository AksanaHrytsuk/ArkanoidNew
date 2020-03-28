using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStick : MonoBehaviour
{
    void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pickup trigger! " + collision.gameObject.name);
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("much faster");
            ApplyEffect();
            Destroy(gameObject);
        }
    else if (collision.gameObject.tag == "LoseGame"){
        //
    }
    }
}
