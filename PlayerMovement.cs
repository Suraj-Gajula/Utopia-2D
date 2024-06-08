using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour{
    private Rigidbody2D PlayerBody;
    private bool IsGrounded;  
    private bool HasJumped;  
    private bool HasDashed;
    public bool IsDashing;
    private Vector2 StartPos;
    private int Direction;
    void Start(){
        PlayerBody = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
            StartPos = Input.GetTouch(0).position;
                if(Input.GetTouch(0).position.x > Screen.width/2){
                    if(IsGrounded){
                        Jump();
                    }
                    else if(HasJumped && !HasDashed){
                        Dash();
                    }
                }
            }
            if(Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x < Screen.width/2){
                float Horizontal = Input.GetTouch(0).position.x - StartPos.x;
                if (Mathf.Abs(Horizontal) > 10f){
                    Direction = (int)Mathf.Sign(Horizontal);
                }
            }
            if(Direction != 0){
                PlayerBody.velocity = new Vector2(10 * Direction, PlayerBody.velocity.y);
            }
        }
        else{
            Direction = 0;
        }
    }
    void Jump(){
        PlayerBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        IsGrounded = false;
        HasJumped = true;  
    }
    void Dash(){
        PlayerBody.AddForce(new Vector2(PlayerBody.velocity.x, 0).normalized * 10, ForceMode2D.Impulse);
        HasDashed = true;
        StartCoroutine(Attack());
    }
    IEnumerator Attack(){
        IsDashing = true;
        yield return new WaitForSeconds(1);
        IsDashing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            IsGrounded = true;
            HasJumped = false;  
            HasDashed = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            IsGrounded = false;
        }
    }
}