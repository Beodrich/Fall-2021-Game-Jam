using Pathfinding;
using UnityEngine;
[RequireComponent(typeof(AIDestinationSetter))]
public class AIMovment : MonoBehaviour
{
    private AIDestinationSetter aIDestinationSetter;
   public void Move(Transform point){
       //print("going to "+ point.gameObject.name);
       aIDestinationSetter.target=point;
   }
    private void Start() {
        aIDestinationSetter=GetComponent<AIDestinationSetter>();
    }
}
