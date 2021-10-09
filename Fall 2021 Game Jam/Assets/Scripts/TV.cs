using System.Collections;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AnimatorLogic))]


public class TV : MonoBehaviour
{
    public PatrolPoint patrolPoint;
    private GameObject player;
    public Healthbar healthbar;

    public int health;



    public float range=5f;

    private AIMovment aIMovment;

    private bool isChasing=false;

    private Shooting shooting;

    public TMP_Text nameText;

    private const string DIE= "tvDie";


    public AudioClip tvDie;
   private void Start() {
       aIMovment=GetComponent<AIMovment>();
       shooting=GetComponent<Shooting>();
       RandomNames.MakeNames();
        nameText.text= RandomNames.GetRandonName();
        player=GameObject.Find("Player");
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
       // if(Mathf.Abs(localVelocity.z) < 0.01f){
         //   Debug.Log("walking backwards");
        //}
    }

    private float InRange()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    public void TakeDamage(){
        health=Mathf.Max(0,health-1);
        healthbar.healthCur = health;
        if(health==0){
            AudioManager.instance.Play(tvDie);
            StartCoroutine(Die());
        }

    }
   private IEnumerator Die(){
        GetComponent<AnimatorLogic>().ChangeAnimationState(DIE);

        

        yield return new WaitForSeconds(0.5f);

        FindObjectOfType<MoveScript>().enemiesKilled += "\n" + nameText.text;
        Destroy(this.gameObject);

    } 
    void Chase(){
        aIMovment.Move(player.transform);
        patrolPoint.setIsPatrol(false);
    }
    void StopChase(){
        patrolPoint.setIsPatrol(true);
    }
    
}

