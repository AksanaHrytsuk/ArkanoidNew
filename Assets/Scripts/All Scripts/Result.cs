using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        Points arkanoid = FindObjectOfType<Points>();
        //Debug.Log(arkanoid);
        int number = arkanoid.addPoints;
        text.text = "Game Over!\n Points: " + number;
        Destroy(arkanoid.gameObject); //destroy gameobjec
    }
}

