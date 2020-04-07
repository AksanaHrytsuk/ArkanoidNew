using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    [Header("Config parameters")]
    public bool invisibleSprite;
    public bool isExploding;
    public float explodeRadius;
    public int hitPoint;
    public int scorePoints;
    public int probability;
   
    [Header("UI Elements")]
    public Sprite[] images;
    //private AudioSource audio;
    public AudioClip destroySound;
    public GameObject destroyFx;
    
    Points pointsControl;
    LevelManager LevelManager;
    SpriteRenderer spriteRenderer;

    public List<GameObject> pickUps;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
        LevelManager.AddBlockCount();
        pointsControl = FindObjectOfType<Points>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (invisibleSprite == true)
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
                ball.ExploudBall();
                this.GetComponent<SpriteRenderer>().sprite = images[hitPoint - 1];
            }
            //Debug.Log(hitPoint);
            else
            {
                DestroyBlock();
                pointsControl.CountPoints(scorePoints);
            }
        }
    }

    public void DestroyBlock()
    {
        LevelManager.RemoveBlockCount();
        
        Destroy(gameObject);
        
        AudioSource audio = FindObjectOfType<AudioSource>();
        audio.PlayOneShot(destroySound);
        
        CreatePickUp(pickUps[Random.Range(0, pickUps.Count +1)]); 
        // CreatePickUp(pickUps[5]); проверка пикапа 
        
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

            if (destroyFx != null)
            {
                Vector3 fxPosition = transform.position;
                GameObject newObject = Instantiate(original: destroyFx, fxPosition, Quaternion.identity);
                Debug.Log("Exploded");
                Destroy(newObject, 2f);
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