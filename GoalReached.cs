using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalReached : MonoBehaviour{
    public Timer TimerObject;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("LevelSelect");
        }
    }
}