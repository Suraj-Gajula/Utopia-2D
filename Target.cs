using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour{
    public PlayerMovement PlayerObject;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && PlayerObject.IsDashing){
            Destroy(gameObject);
        }
    }
}
