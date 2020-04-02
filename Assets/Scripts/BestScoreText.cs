using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BestScoreText : MonoBehaviour
{
    public Text bestScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreTxt.text = "Best score " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
