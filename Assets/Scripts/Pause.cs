using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject image;
    bool pauseActive;
    Platform stopPlatform;


    // Start is called before the first frame update
    void Start()
    {
        // image = FindObjectsOfType<Canvas>();
        // image[0].enabled = false;
        image = GameObject.Find("Pause/Canvas");
        image.SetActive(false);
        stopPlatform = FindObjectOfType<Platform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                image.SetActive(false);
                // turn off Pause
                Time.timeScale = 1;
                pauseActive = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseActive = true;
                stopPlatform.enabled = false;
                image.SetActive(true);
            }
        }
    }
}
