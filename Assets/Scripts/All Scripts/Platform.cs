using PickUps;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("UI Elements")]
    
    Pause pointsCo;
    Ball ball;
    
    [Header("Config Parameters")]
    
    public float minX = -7f;
    public float maxX = 7f;

    public float maxScalePlatform;
    public float minScalePlatform;
   
    private void Start()
    {
        pointsCo = FindObjectOfType<Pause>();
        ball = FindObjectOfType<Ball>();
    }
    void Update()
    {
        if (pointsCo.autoplay && ball.IsStarted())
        {
            MoveWithBall();
        }
        else
        {
            MoveWithMouse();
        }
    }
    void MoveWithMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        // позиция мыши в координатах камеры
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        // позиция мыши в координатах игрового мира

        float mouseX = mouseWorldPos.x;
        // Debug.Log("mousePos: " + mousePos + "mousWorldPos" + mouseWorldPos);
        float clampedMouseX = Mathf.Clamp(mouseX, minX, maxX);
        float platformY = transform.position.y;
        transform.position = new Vector3(clampedMouseX, platformY, 0);
    }
    void MoveWithBall()
    {
        transform.position = new Vector3(ball.transform.position.x, transform.position.y, 0);
    }

    public void ModifiPlatform(float scalePlatform)
    {
        if (transform.localScale.x < maxScalePlatform )
        {
            if (transform.localScale.x > minScalePlatform )
            {
                Vector3 scl = new Vector3(scalePlatform,0,0);
                transform.localScale += scl;
            }
        }
    }
}
