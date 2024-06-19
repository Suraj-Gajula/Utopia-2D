using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour{
    public void ChooseLevel(){
        SceneManager.LoadScene("LevelSelect");
    }
}