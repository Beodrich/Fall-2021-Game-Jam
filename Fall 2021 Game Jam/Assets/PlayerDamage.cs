using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="sinko"){
            Destroy(other.gameObject);
            GetComponent<MoveScript>().currentHealth-=1;
            GetComponent<MoveScript>().pizzaHealth.RemovePizzaSlices(1);
        }
    }
}
