using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLiveInc : MonoBehaviour
{
    Points points;
    public int livesAmount;
    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Platform"))
        {
            //Debug.Log("i'm here");
            var pointsMaxHearts = points.maxHearts + livesAmount;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("LoseGame"))
        {
            Destroy(gameObject);
        }
    }
}
