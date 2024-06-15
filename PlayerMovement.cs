using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour{
    private Rigidbody2D PlayerBody;
    private bool IsGrounded;  
    private bool HasJumped;  
    private bool HasDashed;
    public bool IsDashing;
    private Vector2 StartPos;
    private int Direction;
    public Animator PlayerAnimator;
    public int Apples;
    void Start(){
        Apples = 0;
        PlayerBody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }
    void Update(){
        if (Input.touchCount > 0){
            if (Input.touchCount == 1){
                ButtonHandling(0);
            }
            if (Input.touchCount == 2){
                ButtonHandling(1);
            }
            if (Direction != 0 && !IsDashing){
                Vector2 targetVelocity = new Vector2(10 * Direction, PlayerBody.velocity.y);
                PlayerBody.velocity = Vector2.Lerp(PlayerBody.velocity, targetVelocity, 0.1f);
            }
        }
        else{
            Direction = 0;
        }
        if(transform.position.y < -10){
            Respawn();
        }
        if(PlayerBody.velocity.x != 0){
            PlayerAnimator.SetBool("IsMoving", true);
        }
        else{
            PlayerAnimator.SetBool("IsMoving", false);
        }
    }
    void ButtonHandling(int TouchIndex){
        if (Input.GetTouch(TouchIndex).phase == TouchPhase.Began && Input.GetTouch(TouchIndex).position.x > Screen.width/2){
            VerticalMovement();
        }
        if (Input.GetTouch(TouchIndex).phase == TouchPhase.Moved && Input.GetTouch(TouchIndex).position.x < Screen.width/2){
            HorizontalMovement(Input.GetTouch(TouchIndex));
        }
        else if (Input.GetTouch(TouchIndex).position.x < Screen.width / 2){
            StartPos = Input.GetTouch(TouchIndex).position;
        }
    }
    void VerticalMovement(){
        if (!HasJumped){
            StartCoroutine(Jump());
        }
        else if (HasJumped && !HasDashed){
            StartCoroutine(Dash());
        }
    }
    void HorizontalMovement(Touch HTouch){
        float Horizontal = HTouch.position.x - StartPos.x;
        if (Mathf.Abs(Horizontal) > 10){
            Direction = (int)Mathf.Sign(Horizontal);
        }
    }
    IEnumerator Jump(){
        PlayerBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        IsGrounded = false;
        yield return new WaitForSeconds(0.1f);
        HasJumped = true;  
    }
    IEnumerator Dash()
    {
        HasDashed = true;
        IsDashing = true;
        PlayerAnimator.SetBool("IsDashing", true);
        PlayerBody.gravityScale = 0;
        PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, 0).normalized * 20;
        yield return new WaitForSeconds(0.2f);
        PlayerBody.gravityScale = 1;
        yield return new WaitForSeconds(0.3f);
        IsDashing = false;
        PlayerAnimator.SetBool("IsDashing", true);
    }
    void Respawn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            IsGrounded = true;
            HasJumped = false;  
            HasDashed = false;
            PlayerAnimator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            IsGrounded = false;
            PlayerAnimator.SetBool("IsJumping", true);
        }
    }
}