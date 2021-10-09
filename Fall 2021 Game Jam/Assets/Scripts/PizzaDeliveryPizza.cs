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

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Enemy":
                col.gameObject.GetComponent<TV>().TakeDamage();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Porch":
                if (!col.gameObject.GetComponent<Porch>().hasDelivered)
                {
                    col.gameObject.GetComponent<Porch>().hasDelivered = true;
                    FindObjectOfType<MoveScript>().currentDelivered++;
                    Destroy(col.gameObject);
                    Destroy(gameObject);
                }
                break;
        }
    }
}
