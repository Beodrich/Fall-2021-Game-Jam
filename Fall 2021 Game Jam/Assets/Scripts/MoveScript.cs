using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float vertical = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.AddForce(moveDirection * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
