using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public AudioClip MENTALSTATEGOBRRRRRRRRRRR43RRRRRRRRRRRRRRRRERRRRRRRRRR;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="sinko"){
            AudioManager.instance.Play(MENTALSTATEGOBRRRRRRRRRRR43RRRRRRRRRRRRRRRRERRRRRRRRRR);
            Destroy(other.gameObject);
            GetComponent<MoveScript>().currentHealth-=1;
            GetComponent<MoveScript>().pizzaHealth.RemovePizzaSlices(1);
        }
    }
}
