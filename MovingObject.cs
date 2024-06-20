using UnityEngine;
public class MovingObject : MonoBehaviour{
    public Vector2[] Positions;
    private Rigidbody2D PlatformBody;
    private Vector2 targetPosition;
    private bool movingToB = true;
    private int currentPosition = 0;
    void Start(){
        PlatformBody = GetComponent<Rigidbody2D>();
        targetPosition = Positions[currentPosition];
    }
    void FixedUpdate(){
        PlatformBody.MovePosition(Vector2.MoveTowards(PlatformBody.position, targetPosition, Time.fixedDeltaTime));
        if (Vector2.Distance(PlatformBody.position, targetPosition) < 0.01f){
            currentPosition = (currentPosition + 1) % Positions.Length;
            targetPosition = Positions[currentPosition];
        }
    }
}