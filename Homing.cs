using UnityEngine;

public class Homing : MonoBehaviour{
    public Transform player;
    private Vector2 targetDirection;
    private Rigidbody2D HazardBody;
    void Start(){
        HazardBody = GetComponent<Rigidbody2D>();
        targetDirection = ((Vector2)player.position - HazardBody.position).normalized;
        Destroy(gameObject, 10f);
    }
    void FixedUpdate(){
        HazardBody.velocity = targetDirection * 5;
    }
}
