using UnityEngine;

namespace PickUps
{
    public class PickUpKIllLive : MonoBehaviour
    {
        Points points;

        // Start is called before the first frame update
        void Start()
        {
            points = FindObjectOfType<Points>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                points.BallDown();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("LoseGame"))
            {
                Destroy(gameObject);
            }
        }
    }
}