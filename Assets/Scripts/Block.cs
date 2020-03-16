using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public Sprite[] images;
    public int hitPoint;
    public int scorePoints;
    public Points pointsControl;
    LevelManager LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
        LevelManager.AddBlockCount();
        pointsControl = FindObjectOfType<Points>();
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoint++;
        if (hitPoint < 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = images[hitPoint - 1];
        }
        //Debug.Log(hitPoint);
        else
        {
            DestroyBlock();
            pointsControl.countPoints(scorePoints);
        }
    }
    void DestroyBlock()
    {
        LevelManager.RemoveBlockCount();
        Destroy(gameObject);
    }
}
