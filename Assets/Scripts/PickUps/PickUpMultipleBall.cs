using UnityEngine;

namespace PickUps
{
    public class PickUpMultipleBall : MonoBehaviour
    {
        public int ballsNumber = 2;
        void ApplyEffect()
        {
            Ball[] ball = FindObjectsOfType<Ball>();
            for (int i = 0; i < ball.Length; i++)
            {
                ball[i].Duplicate();
            }
        
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Pickup trigger! " + collision.gameObject.name);
            if (collision.gameObject.CompareTag("Platform"))
            {
                ApplyEffect();
                Destroy(gameObject);
            }
        } 
    
    }
}
