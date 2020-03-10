using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    private int addPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    public void countPoints(int score)
    {

        addPoints +=score;
        points.text = "Points: " + addPoints;
    }
}
