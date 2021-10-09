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

        bool wack;
        //bread gaming
        private const string BREAD_WHACK="breadStickWack";
        private const string DEFAULT="New State";

        public AudioClip BONK;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { //objectPos.x

mouse_pos = Input.mousePosition;
     
     
     
        
        
        if (WhackLag <= 0) // 
        {
            if (Input.GetMouseButtonDown(0))
            {
            GetComponent<AnimatorLogic>().ChangeAnimationState(BREAD_WHACK);
            StartCoroutine(PlayAnimation());
            AudioManager.instance.Play(BONK);

           Collider2D[] CheckDamage = Physics2D.OverlapCircleAll(Whackpos.position, WhackRadius, DefineEnemy);
            Debug.Log("Trigger down");
           for (int i = 0; i<CheckDamage.Length; i++ )
           {
               Debug.Log("Found Target, applying damage");
               CheckDamage[i].GetComponent<TV>().TakeDamage();
               wack=true;
           }
            }
            //else   GetComponent<AnimatorLogic>().ChangeAnimationState(DEFAULT);

            


        }
        else{
        WhackLag -= Time.deltaTime; 

        }
    }

    void OnDrawGizmosSelected()
    {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(Whackpos.position, WhackRadius);

    }

IEnumerator PlayAnimation(){
    yield return new WaitForSeconds(.3f);
    GetComponent<AnimatorLogic>().ChangeAnimationState(DEFAULT);

    
}
}

