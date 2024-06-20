using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour{
    public void SelectLevel(int Level){
        TimeManager.SetLevel(Level);
        SceneManager.LoadScene("Boss" + Level.ToString());
    }
}