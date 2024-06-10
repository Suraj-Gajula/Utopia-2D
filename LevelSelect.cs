using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour{
    public void SelectLevel(int Level){
        TimeManager.SetLevel(Level);
        SceneManager.LoadScene("Level" + Level.ToString());
    }
}