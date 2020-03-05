using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float minX = -7f;
    public float maxX = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Camera.main.ScreenToWorldPoint(mousePos);
        float mouseX = mouseWorldPos.x;
        // Debug.Log("mousePos: " + mousePos + "mousWorldPos" + mousWorldPos);
        float clampedMouseX = Mathf.Clamp(mouseX, minX, maxX);
        float platformY = transform.position.y;
        transform.position = new Vector3(clampedMouseX, platformY, 0);

    }
}
