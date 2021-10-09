
using UnityEngine;

public class Fire : MonoBehaviour
{
    Transform player;
    Vector2 target;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player").transform;
        target=new Vector2(player.position.x,player.position.y);
        /*come back to this*/
        Destroy(this.gameObject,3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);

    }
}
