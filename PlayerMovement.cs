using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour{
    private Rigidbody2D PlayerBody;
    private bool IsGrounded;  
    private bool HasJumped;  
    private bool HasDashed;
    public bool IsDashing;
    private int DashSpeed = 1;
    private Vector2 StartPos;
    private int Direction;
    void Start(){
        PlayerBody = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if(Input.touchCount > 0){
            if(Input.touchCount == 1){
                if(Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x > Screen.width/2){
                    VerticalMovement();
                }
                if(Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x < Screen.width/2){
                    HorizontalMovement(Input.GetTouch(0));
                }
                else if(Input.GetTouch(0).position.x < Screen.width/2){
                    StartPos = Input.GetTouch(0).position;
                    }
                    }
                    else if(HasJumped && !HasDashed){
                        Dash();
                }
                    else if(HasJumped && !HasDashed){
                        Dash();
            }
            if(Input.touchCount == 2){
                if(Input.GetTouch(1).phase == TouchPhase.Began && Input.GetTouch(1).position.x > Screen.width/2){
                    VerticalMovement();
                }
                if(Input.GetTouch(1).phase == TouchPhase.Moved && Input.GetTouch(1).position.x < Screen.width/2){
                    HorizontalMovement(Input.GetTouch(1));
                }
                else if(Input.GetTouch(1).position.x < Screen.width/2){
                    StartPos = Input.GetTouch(1).position;
                }
            }
            if(Direction != 0){
                PlayerBody.velocity = new Vector2(10 * Direction * DashSpeed, PlayerBody.velocity.y);
            }
        }

        else{
            Direction = 0;
        }
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }
    void VerticalMovement(){
        if(!HasJumped){
            StartCoroutine(Jump());
        }
        else if(HasJumped && !HasDashed){
            StartCoroutine(Dash());
        }
    }
    void HorizontalMovement(Touch HTouch){
        float Horizontal = HTouch.position.x - StartPos.x;
        if (Mathf.Abs(Horizontal) > 100){
            Direction = (int)Mathf.Sign(Horizontal);
        }
    }
    IEnumerator Jump(){
        PlayerBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        IsGrounded = false;
        yield return new WaitForSeconds(0.1f);
        HasJumped = true;  
    }
    IEnumerator Dash(){
        HasDashed = true;
        DashSpeed = 2;
         IsDashing = true;
        yield return new WaitForSeconds(0.5f);
        IsDashing = false;
        DashSpeed = 1;
    }
    void Respawn(){
        transform.position = new Vector3(0, 0, 0);
        PlayerBody.velocity = Vector2.zero;
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