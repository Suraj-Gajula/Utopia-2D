using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour{
    public Boss boss;
    public Image HealthbarFill;
    private int MaxFill;
    void Start(){
        MaxFill = boss.Health;
    }
    void Update(){
        HealthbarFill.fillAmount = (float)boss.Health/(float)MaxFill;
    }
}
