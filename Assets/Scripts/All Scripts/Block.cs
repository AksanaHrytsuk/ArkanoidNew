using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    [Header("Config parametrs")]
    public bool InvisibleSprite;
    public bool isExploding;
    public float explodeRadius;
    public int hitPoint;
    public int scorePoints;

    public Sprite[] images;
    
    [Header("UI Elements")]
    Points pointsControl;
    LevelManager LevelManager;
    SpriteRenderer spriteRenderer;
    
    
    public GameObject pickupSpeed;
    public GameObject pickupUpPoints;
    public GameObject pickupDownPoints;
    public GameObject pickupStickBall;
    public GameObject pickupDoubleBall;
    public GameObject pickupIncreaseScaleBall;
    public GameObject pickupReduceScaleBall;
    public GameObject pickupReduceScalePlatform;
    public GameObject pickupIncreaseScalePlatform;
    public GameObject pickupGiveLive;
    public GameObject pickupTakeLive;
    public GameObject pickupBallExpl;


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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            hitPoint++;
            if (hitPoint <= images.Length)
            {
                Ball ball = FindObjectOfType<Ball>();
                ball.Exploud();
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

    public void DestroyBlock()
    {
        Debug.Log(gameObject.name);
        LevelManager.RemoveBlockCount();
        Destroy(gameObject);
        CreatePickUp(pickupSpeed);
        CreatePickUp(pickupUpPoints);
        CreatePickUp(pickupDownPoints);
        CreatePickUp(pickupStickBall);
        CreatePickUp(pickupDoubleBall);
        CreatePickUp(pickupIncreaseScaleBall);
        CreatePickUp(pickupReduceScaleBall);
        CreatePickUp(pickupReduceScalePlatform);
        CreatePickUp(pickupIncreaseScalePlatform);
        CreatePickUp(pickupGiveLive);
        CreatePickUp(pickupTakeLive);
        CreatePickUp(pickupBallExpl);
        if (isExploding)
        {
            //explode

            //layer mask to filter physics objects
            LayerMask layerMask = LayerMask.GetMask($"Block");

            //find objects in radius
            Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);


            foreach (Collider2D objectI in objectsInRadius)
            {
                if (objectI.gameObject == gameObject)
                {
                    continue; //the same gameObject ==> next iteration
                }

                Block block = objectI.gameObject.GetComponent<Block>();
                if (block == null)
                {
                    Destroy(objectI.gameObject);
                }
                else
                {
                    block.DestroyBlock();
                }
            }
            
        }

        void CreatePickUp(GameObject pick)
        {
            if (pick != null)
            {
                Vector3 pickupPosition = transform.position;

                // pickupPosition.x += Random.Range(-1, 1);
                //Instantiate(pickup, ModifySpeed, Quaternion.identity);
                if (Chance())
                {
                    GameObject newObject = Instantiate(pick);
                    newObject.transform.position = pickupPosition;

                    Vector3 direction = new Vector3(Random.Range(-100f, 100f), 100, 0);
                    newObject.GetComponent<Rigidbody2D>().AddForce(direction);
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