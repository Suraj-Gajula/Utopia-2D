using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour{
    public void SelectLevel(int Level){
        if(Level == 1){
            SceneManager.LoadScene("Level1");
        }
    }
}