using UnityEngine;
public class Target : MonoBehaviour{
    public PlayerMovement PlayerObject;
    public GoalReached goalReached;
    void Start(){
        goalReached.TargetsLeft += 1;}
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && PlayerObject.IsDashing){
            goalReached.TargetsLeft -= 1;
            Destroy(gameObject);
        }
    }
}