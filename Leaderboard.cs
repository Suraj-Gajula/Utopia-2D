using UnityEngine;
using TMPro;
using System.Text;
public class Leaderboard : MonoBehaviour{
    public GameObject LeaderboardBG;
    public GameObject LeaderboardReset;
    public GameObject UpdatesButton;
    public TextMeshProUGUI LeaderBoardText;
    public void ActivateLeaderboard(){
        UpdatesButton.SetActive(!UpdatesButton.activeSelf);
        LeaderboardBG.SetActive(!LeaderboardBG.activeSelf);
        LeaderboardReset.SetActive(!LeaderboardReset.activeSelf);
        SetLeaderboard();
    }
    public void SetLeaderboard(){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 1; i++){
            sb.AppendLine($"Level {i + 1}: {TimeManager.GetTimeSet(i).ToString()}");
        }
        LeaderBoardText.text = sb.ToString();
    }
    public void ResetLeaderboard(){
        TimeManager.ResetAllTimeSets();
        SetLeaderboard();
    }
}