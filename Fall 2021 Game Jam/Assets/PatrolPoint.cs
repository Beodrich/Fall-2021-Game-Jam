
using UnityEngine;
using Pathfinding;


public class PatrolPoint : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int wayPointIndex;
    private AIDestinationSetter aIDestinationSetter;

    public float coolDownTimer=1f;

    private float startingCoolDown;
    void Start()
    {
        aIDestinationSetter=GetComponent<AIDestinationSetter>();
        startingCoolDown=coolDownTimer;
    }

    void Patrol(){
        aIDestinationSetter.target= patrolPoints[wayPointIndex];
    }
    void UpdateIndex(){
        ++wayPointIndex;
        if(wayPointIndex>=patrolPoints.Length){
            wayPointIndex=0;
        }
    }
        
    private void Update() {
        float difference= Vector3.Distance(patrolPoints[wayPointIndex].position,transform.position);
        if(difference<1f)
        {
           
            UpdateIndex();
            
           
        
        }
       
         
        Patrol();
   
   
    }

    private void DecreaseTimer()
    {
        coolDownTimer -= Time.deltaTime;
    }

    private void ResetTimer()
    {
        coolDownTimer = startingCoolDown;
    }


}
