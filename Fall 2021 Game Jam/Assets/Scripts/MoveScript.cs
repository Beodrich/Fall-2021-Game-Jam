using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public static int maxHealth = 8;
    public int currentHealth;
    public int currentPizzas = 6;
    public PizzaHealth pizzaHealth;

    public const string PLAYER_MOVE_ANIMATION="player_walk";
    public const string PLAYER_IDEL_ANIMATION="player idel";




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        float horizontal = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float vertical = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        rb.AddForce(moveDirection * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pizzaHealth.RemovePizzaSlices(1);
        }

        if (currentPizzas > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Shooting>().Shoot(1.5f);
                currentPizzas -= 1;
            }
        }
        
        PlayAnimation();
    }

    void PlayAnimation(){
        if(rb.velocity.magnitude<=1f){
            //play ideal animation
            GetComponent<AnimatorLogic>().ChangeAnimationState(PLAYER_IDEL_ANIMATION);

        }
        else{
        GetComponent<AnimatorLogic>().ChangeAnimationState(PLAYER_MOVE_ANIMATION);

        }

    
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Health":
                pizzaHealth.RemovePizzaSlices(-1);
                Destroy(col.gameObject);
                break;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Pizza":
                currentPizzas += 1;
                Destroy(col.gameObject);
                break;
        }
    }
}
