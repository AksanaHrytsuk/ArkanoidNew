using UnityEngine;

namespace PickUps
{
    public class PickUpStick : MonoBehaviour
    {
        void ApplyEffect()
        {
            Ball ball = FindObjectOfType<Ball>();
            ball.MadeSticky();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Debug.Log("Pickup trigger! " + collision.gameObject.name);
            if (collision.gameObject.CompareTag("Platform"))
            {
                ApplyEffect();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("LoseGame")){
                //
            }
        }
    }
}
