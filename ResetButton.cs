using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetButton : MonoBehaviour{
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; 
    }
}