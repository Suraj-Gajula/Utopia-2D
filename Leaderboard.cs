using UnityEngine;
using TMPro;
using System.Text;
public class Leaderboard : MonoBehaviour{
    public GameObject LeaderboardBG;
    public GameObject LeaderboardReset;
    public TextMeshProUGUI LeaderBoardText;
    public void ActivateLeaderboard(){
        LeaderboardBG.SetActive(!LeaderboardBG.activeSelf);
        LeaderboardReset.SetActive(!LeaderboardReset.activeSelf);
        SetLeaderboard();
    }
    public void SetLeaderboard(){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 10; i++){
            sb.AppendLine($"Level {i + 1}: {TimeManager.GetTimeSet(i).ToString()}");
        }
        LeaderBoardText.text = sb.ToString();
    }
    public void ResetLeaderboard(){
        TimeManager.ResetAllTimeSets();
        SetLeaderboard();
    }
}