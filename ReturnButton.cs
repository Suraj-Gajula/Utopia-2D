using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnButton : MonoBehaviour{
    public void Return(){
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1f; 
    }
}