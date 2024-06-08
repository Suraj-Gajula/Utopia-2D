using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseButton : MonoBehaviour{
   private bool IsPaused = false;
   public GameObject Tint;
    public void Pause(){
        IsPaused = !IsPaused;
        if (IsPaused){
            Tint.SetActive(true);
            Time.timeScale = 0f; 
        }
        else{
            Tint.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
