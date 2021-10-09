using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCamera : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 beginningOffset;
    // Start is called before the first frame update
    void Start()
    {
        beginningOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraTransform.position + beginningOffset;
    }
}
