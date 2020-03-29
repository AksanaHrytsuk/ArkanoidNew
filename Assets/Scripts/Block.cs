using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public bool isExploding;
    public float explodeRadius;

    public Sprite[] images;
    public int hitPoint;
    public int scorePoints;
    Points pointsControl;
    LevelManager LevelManager;
    SpriteRenderer spriteRenderer;
    public bool InvisibleSprite;
    public GameObject pickupSpeed;
    public GameObject pickupUpPoints;
    public GameObject pickupDownPoints;
    public GameObject pickupStickBall;
    public GameObject pickupDoubleBall;
    public GameObject pickupIncreaseScaleBall;
    public GameObject pickupReduceScaleBall;
    //public GameObject pickupReduceScalePlatform;
    public GameObject pickupIncreaseScalePlatform;



   //public GameObject pickupScalePlatform;
    public int probability;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
        LevelManager.AddBlockCount();
        pointsControl = FindObjectOfType<Points>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (InvisibleSprite == true)
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
        // CreatePickUp(pickupSpeed);
        // CreatePickUp(pickupUpPoints);
        // CreatePickUp(pickupDownPoints);
        // CreatePickUp(pickupStickBall);
        // CreatePickUp(pickupDoubleBall);
        //CreatePickUp(pickupIncreaseScaleBall);
        //CreatePickUp(pickupReduceScaleBall);
        //CreatePickUp(pickupReduceScalePlatform);
        CreatePickUp(pickupIncreaseScalePlatform);
        if (isExploding)
        {
           // LayerMask layerMask = layerMask.GetMask("Block");

            //explode
            Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius);

            // for (int i = 0; i < objectsInRadius.Length; i++)
            //{
            //Collider2D objectI = objectsInRadius[i];

            // }
            foreach (Collider2D objectI in objectsInRadius)
            {
                Block block = objectI.gameObject.GetComponent<Block>();
                if (block == null)
                {
                    Destroy(objectI.gameObject);
                }
                else
                {
                    block.DestroyBlock();
                }
                Debug.Log(objectI.gameObject.name);
                Destroy(objectI.gameObject);
            }
        }
        void CreatePickUp(GameObject pick)
        {
            if (pick != null)
            {
                Vector3 pickupPosition = transform.position;
                pickupPosition.x += Random.Range(-1, 1);
                //Instantiate(pickup, ModifySpeed, Quaternion.identity);
                if (Chance())
                {
                    GameObject newObject = Instantiate(pick);
                    newObject.transform.position = pickupPosition;
                }
            }
        }
        bool Chance()
        {

            int chance = Random.Range(0, 100);
            if (chance < probability)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    void OnDrawGizmos()
    {
     Gizmos.color = Color.white;
     Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}

