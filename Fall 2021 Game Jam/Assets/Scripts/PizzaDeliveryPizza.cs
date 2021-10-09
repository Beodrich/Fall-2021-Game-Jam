using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDeliveryPizza : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shootStrength;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePos - FindObjectOfType<MoveScript>().transform.position);
        rb.AddForce(shootStrength * dir.normalized, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
