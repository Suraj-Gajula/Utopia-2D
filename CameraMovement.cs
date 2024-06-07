using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour{
   public Transform Target;
   void Update(){
        transform.position = Target.position + new Vector3(0, 2, -10);
   }
}