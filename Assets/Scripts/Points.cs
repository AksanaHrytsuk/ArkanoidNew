using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    public int addPoints;
    // Start is called before the first frame update
    private void Awake()
    {
        Points[] pointsList = FindObjectsOfType<Points>();
        Debug.Log(pointsList.Length);
        if (pointsList.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
         DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void countPoints(int score)
    {
        addPoints += score;
        points.text = "Points: " + addPoints;
        DontDestroyOnLoad(gameObject);
    }
}
