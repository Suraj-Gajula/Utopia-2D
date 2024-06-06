using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D PlayerBody;
    private bool IsGrounded;   
    void Start(){
        PlayerBody = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)){
            if (IsGrounded){
                Jump();
            }
        }
    }
    void Jump(){
        PlayerBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        IsGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            IsGrounded = false;
        }
    }
}
