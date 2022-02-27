
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform player;
   Vector3 offset;
   private void Start(){
       offset=transform.position-player.position;
   }
   private void Update(){
       Vector3 targetPosition=player.position+offset;
       targetPosition.x=1.42f;
       transform.position=targetPosition;
   }
}
