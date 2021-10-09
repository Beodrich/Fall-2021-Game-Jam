
using UnityEngine;


public class TV : MonoBehaviour
{
    public PatrolPoint patrolPoint;
    public GameObject player;

    public int health;



    public float range=5f;

    private AIMovment aIMovment;

    private bool isChasing=false;

    private Shooting shooting;

   private void Start() {
       aIMovment=GetComponent<AIMovment>();
       shooting=GetComponent<Shooting>();
   }
    

    // Update is called once per frame
    void Update()
    {
        if(InRange()<=range){
            Chase();
            isChasing=true;

        }
        else{
            StopChase();
            isChasing=false;
        }
        if(isChasing){
            shooting.CheckForShoot();
        }
    }

    private float InRange()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    void TakeDamage(){
        health=Mathf.Max(0,health-1);
        if(health==0){
            Destroy(this.gameObject);

        }

    }
    void Chase(){
        aIMovment.Move(player.transform);
        patrolPoint.setIsPatrol(false);
    }
    void StopChase(){
        patrolPoint.setIsPatrol(true);
    }
    
}

