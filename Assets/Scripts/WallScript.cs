using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallScript : MonoBehaviour
{
   public Points points;
  
        private void Start()
    {
        points = FindObjectOfType<Points>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        points.ballDown();
    }
}
