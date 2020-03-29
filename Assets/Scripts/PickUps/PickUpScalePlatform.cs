using UnityEngine;

namespace PickUps
{
    public class PickUpScalePlatform : MonoBehaviour
    {
        public float changeScale;

        private Platform _platform;

        private Ball _ball;
        // Start is called before the first frame update

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                _platform = FindObjectOfType<Platform>();
                _platform.ModifiScalePlatform(changeScale);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("LoseGame"))
            {
                Destroy(gameObject);
            }
        }
    }
}
