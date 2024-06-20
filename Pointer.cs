using UnityEngine;
public class Pointer : MonoBehaviour{
    public Transform pointer;
    public Transform player;
    public Transform target; 
    void Update(){
        float Distance = Vector2.Distance(player.position, target.position);
        if(Distance >= 10){
            pointer.gameObject.SetActive(true);
            Vector3 Direction = target.position - pointer.position;
            float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            float x = player.position.x + Mathf.Cos(Angle * Mathf.Deg2Rad) * 2;
            float y = player.position.y + Mathf.Sin(Angle * Mathf.Deg2Rad) * 2;
            pointer.position = new Vector2(x, y);
        }
        else{
            pointer.gameObject.SetActive(false);
        }
    }
}
