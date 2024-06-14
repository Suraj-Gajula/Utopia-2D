using UnityEngine;
using TMPro;
public class ShowUpdates : MonoBehaviour{
    public GameObject UpdatesBG;
    public GameObject LeaderboardButton;
    public TextMeshProUGUI UpdatesText;
    public void ActivateUpdates(){
        LeaderboardButton.SetActive(!LeaderboardButton.activeSelf);
        UpdatesBG.SetActive(!UpdatesBG.activeSelf);
        UpdatesText.text = "V1.0: Initial Release";
    }
}
