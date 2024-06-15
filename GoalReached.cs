using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GoalReached : MonoBehaviour{
    public Timer timer;
    public int TargetsLeft;
    public TextMeshProUGUI TargetText;
    public TextMeshProUGUI CollectibleText;
    public PlayerMovement Player;
    void Update(){
        TargetText.text = TargetsLeft.ToString() + " Targets Left";
        CollectibleText.text = Player.Apples + "/100 Apples";
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && TargetsLeft == 0){
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
}