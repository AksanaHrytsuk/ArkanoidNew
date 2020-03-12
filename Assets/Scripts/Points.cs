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
        // Debug.Log("Hi");
        Points[] points = FindObjectsOfType<Points>();
        if (points.Length > 1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
    void Start()
    {
       // Debug.Log("Choos");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
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
        addPoints +=score;
        points.text = "Points: " + addPoints;
        DontDestroyOnLoad(gameObject);
    }
}
