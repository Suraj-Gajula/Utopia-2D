using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseButton : MonoBehaviour{
    private bool IsPaused = false;
    public GameObject Tint;
    public GameObject Restart;
    public void Pause(){
        IsPaused = !IsPaused;
        if (IsPaused){
            Restart.SetActive(true);
            Tint.SetActive(true);
            Time.timeScale = 0f; 
        }
        else{
            Restart.SetActive(false);
            Tint.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
