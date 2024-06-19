using UnityEngine;
public class CameraMovement : MonoBehaviour{
   public Transform Target;
   public Transform Background;
   void Update(){
      transform.position = Target.position + new Vector3(0, 0, -10);
      Background.position = Target.position + new Vector3(0, 0, 1);
   }
}