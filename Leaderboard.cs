using UnityEngine;
using TMPro;
public class Leaderboard : MonoBehaviour{
    public GameObject LeaderboardBG;
    public TextMeshProUGUI LeaderBoardText;
    public void ActivateLeaderboard(){
        LeaderboardBG.SetActive(!LeaderboardBG.activeSelf);
        LeaderBoardText.text = TimeManager.GetTimeSet(0).ToString();

    }
}