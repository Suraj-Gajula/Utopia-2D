using UnityEngine;
public class Collectible : MonoBehaviour{
    public PlayerMovement Player;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            Player.Apples += 1;
        }
    }
}