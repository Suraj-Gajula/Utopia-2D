using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoalReached : MonoBehaviour{
    public Timer TimerObject;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            TimerObject.Restart();
        }
    }
}
