using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour{
    public TextMeshProUGUI TimerText;
    private float ElapsedTime = 0f;
    void Update(){
        ElapsedTime += Time.deltaTime;
        int Minutes = Mathf.FloorToInt(ElapsedTime / 60f);
        int Seconds = Mathf.FloorToInt(ElapsedTime % 60f);
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);;
    }
}
