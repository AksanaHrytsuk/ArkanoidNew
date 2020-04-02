using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject image;
    bool pauseActive;
    Platform stopPlatform;
    public bool autoplay;
    public float autoplaySpead = 1.5f;
    public WallDownScript wallDownScripts;


    // Start is called before the first frame update
    void Start()
    {
        // image = FindObjectsOfType<Canvas>();
        // image[0].enabled = false;
       // image = GameObject.Find("Pause/Canvas");
        image.SetActive(false);
        stopPlatform = FindObjectOfType<Platform>();
        if (autoplay)
        {
            Time.timeScale = autoplaySpead;
        }
        wallDownScripts = FindObjectOfType<WallDownScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                if (autoplay)
                {
                    Time.timeScale = autoplaySpead;
                }
                else
                {
                    Time.timeScale = 1;
                }
                image.SetActive(false);
                // turn off Pause
                stopPlatform.enabled = true;
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
