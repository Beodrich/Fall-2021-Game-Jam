using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticWorldRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
