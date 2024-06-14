using UnityEngine;
public class CameraMovement : MonoBehaviour{
   public Transform Target;
   void Update(){
      transform.position = Target.position + new Vector3(0, 0, -10);
   }
}