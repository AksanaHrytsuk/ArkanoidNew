using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float minX = -7f;
    public float maxX = 7f;
    // Update is called once per frame
    void Update()
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
}
