using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour{
    public int Health;
    public PlayerMovement player;
    public Timer timer;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && player.IsDashing){
            Health -= 1;
            if(Health == 0){
                int Minutes = Mathf.FloorToInt(timer.ElapsedTime / 60f);
                int Seconds = Mathf.FloorToInt(timer.ElapsedTime % 60f);
                if(Minutes < TimeManager.GetCurrentMinutes() || 
                (Minutes == TimeManager.GetCurrentMinutes() && Seconds < TimeManager.GetCurrentSeconds()) || 
                ((TimeManager.GetCurrentMinutes() == 0 && TimeManager.GetCurrentMinutes() == 0))){
                    TimeManager.SetTimeSet(Minutes, Seconds);
                }
                SceneManager.LoadScene("LevelSelect");
            }
        }
        else if(collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
