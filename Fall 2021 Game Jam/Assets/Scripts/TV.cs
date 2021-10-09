using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TV : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    public int health;
    
    private void Start() {
        agent=GetComponent<NavMeshAgent>();
        agent.updateRotation=false;
        agent.updatePosition=false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
    public void Die(){

    }
}
