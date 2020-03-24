using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Pause pointsCo;
    Ball ball;
    public float minX = -7f;
    public float maxX = 7f;
    // Update is called once per frame
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
}
