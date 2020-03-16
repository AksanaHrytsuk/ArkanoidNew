using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    private int addPoints;
    bool pauseActive;
    // Start is called before the first frame update
    private void Awake()
    {
        Points[] pointsList = FindObjectsOfType<Points>();
        Debug.Log(pointsList.Length);
        // if (pointsList.Length > 2)
        // {
        //     gameObject.SetActive(false);
        //     Destroy(gameObject);
        // }
    }
     void Start()
     {
        Debug.Log("Choos");
     }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                // turen off Pause
                pauseActive = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseActive = true;
            }
        }
    }

    public void countPoints(int score)
    {
        addPoints += score;
        points.text = "Points: " + addPoints;
        DontDestroyOnLoad(gameObject);
    }
}
