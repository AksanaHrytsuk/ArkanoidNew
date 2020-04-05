using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        // Find all musicPlayers on the scene
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();
        // Debug.Log(musicPlayers.Length);
        if (musicPlayers.Length > 1)
        {
            // if more then one => destroy gameObject
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
