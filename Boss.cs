using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour{
    public int Health;
    public PlayerMovement player;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && player.IsDashing){
            Health -= 1;
            if(Health == 0){
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
