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
    public SpriteRenderer spriteRenderer;
    public bool spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
        LevelManager.AddBlockCount();
        pointsControl = FindObjectOfType<Points>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRend == true)
        {
            spriteRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
        else
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
    }
    void DestroyBlock()
    {
        LevelManager.RemoveBlockCount();
        Destroy(gameObject);
    }
}

