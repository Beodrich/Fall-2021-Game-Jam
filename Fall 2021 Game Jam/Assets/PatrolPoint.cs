
using UnityEngine;
using Pathfinding;


public class PatrolPoint : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int wayPointIndex;

    public float coolDownTimer=1f;

    private float startingCoolDown;

    private Transform lastPatrolPoint;

    private bool canPatrol=true;

    private AIMovment aIMovment;
    void Start()
    {
        startingCoolDown=coolDownTimer;
        aIMovment=GetComponent<AIMovment>();
    }

    void Patrol(){
        aIMovment.Move(patrolPoints[wayPointIndex]);

    }
    void UpdateIndex(){
        ++wayPointIndex;
        if(wayPointIndex>=patrolPoints.Length){
            wayPointIndex=0;
        }
    }
        
    private void Update() {
        if(canPatrol){
        float difference= Vector3.Distance(patrolPoints[wayPointIndex].position,transform.position);
        if(difference<1f)
        {
           
            UpdateIndex();
            
           
        
        }
       
         
        Patrol();
   
   
    }
    }

    private void DecreaseTimer()
    {
        coolDownTimer -= Time.deltaTime;
    }

    private void ResetTimer()
    {
        coolDownTimer = startingCoolDown;
    }

    public void SetLastPoint(Transform lastPoint){
        lastPatrolPoint=lastPoint;
    }
    public void setIsPatrol(bool value){
        this.canPatrol=value;
    }
   public Transform getLastWayPoint(){
       return  patrolPoints[wayPointIndex];
   }
}
