using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackScript : MonoBehaviour
{
    private float WhackLag; //No spam clicking
    public float WhackLagStart; 
    public Transform Whackpos; //Attack Position
    public float WhackRadius; //Attack HitBox Radius

    public LayerMask DefineEnemy;
    public int damage; 

       Vector3 mouse_pos;
       Vector3 object_pos;
       public Transform target;
       public float angle; 
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { //objectPos.x

mouse_pos = Input.mousePosition;
     
     
     mouse_pos.z = 5; //The distance between the camera and object
     object_pos = Camera.main.WorldToScreenPoint(target.position);
     mouse_pos.x = mouse_pos.x - object_pos.x;
     mouse_pos.y = mouse_pos.y - object_pos.y;
     angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.Euler(0, 0, angle);
     
        
        
        if (WhackLag <= 0) // 
        {
            if (Input.GetMouseButtonDown(0))
            {
           Collider2D[] CheckDamage = Physics2D.OverlapCircleAll(Whackpos.position, WhackRadius, DefineEnemy);
            Debug.Log("Trigger down");
           for (int i = 0; i<CheckDamage.Length; i++ )
           {
               Debug.Log("Found Target, applying damage");
               CheckDamage[i].GetComponent<TV>().health -= damage;
           }
            }


        }
        else 
        WhackLag -= Time.deltaTime; 
    }

    void OnDrawGizmosSelected()
    {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(Whackpos.position, WhackRadius);

    }

}
