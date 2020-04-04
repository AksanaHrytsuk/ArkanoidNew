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
        int number = arkanoid.addPoints;
        text.text = "Points: " + number;
        Destroy(arkanoid.gameObject); //destroy gameObject
        
        int previousScore = PlayerPrefs.GetInt("BestScore", 0);
        
        if (number > previousScore)
        {
            PlayerPrefs.SetInt("BestScore", number);
        }
    }
}

