using UnityEngine;
public class Teleporter : MonoBehaviour{
    public Teleporter TargetTeleporter;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            other.transform.position = TargetTeleporter.transform.position + new Vector3(0, -2, 0);
        }
    }
}