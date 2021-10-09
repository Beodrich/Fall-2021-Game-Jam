using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCamera : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 beginningOffset;
    public Vector2 cameraBoundary;
    private Camera thisCamera;
    // Start is called before the first frame update
    void Start()
    {
        beginningOffset = transform.position;
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPos = cameraTransform.position + beginningOffset;
        Vector3 newPos = cameraTransform.position + new Vector3(0,0,-10);
        float halfHeight = thisCamera.orthographicSize;
        float halfWidth = thisCamera.aspect * halfHeight;
        newPos.x = Mathf.Clamp(newPos.x, halfWidth, cameraBoundary.x - halfWidth);
        newPos.y = Mathf.Clamp(newPos.y, halfHeight, cameraBoundary.y - halfHeight);
        transform.position = newPos;
    }
}
