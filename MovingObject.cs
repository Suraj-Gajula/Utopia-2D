using UnityEngine;
public class MovingObject : MonoBehaviour{
    public Vector2 positionA;
    public Vector2 positionB;
    private Rigidbody2D PlatformBody;
    private Vector2 targetPosition;
    private bool movingToB = true;
    void Start(){
        PlatformBody = GetComponent<Rigidbody2D>();
        targetPosition = positionB;
    }
    void FixedUpdate(){
        PlatformBody.MovePosition(Vector2.MoveTowards(PlatformBody.position, targetPosition, Time.fixedDeltaTime));
        if (Vector2.Distance(PlatformBody.position, targetPosition) < 0.01f){
        targetPosition = movingToB ? positionA : positionB;
            movingToB = !movingToB;
        }
    }
}



