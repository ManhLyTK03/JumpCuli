using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    public Transform player;
    public Transform Camera;
    public float decrease = 3.2f;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance != null && GameManager.instance.GetHighScore()%10 != 0 && choiceMap.checkMap){
            Vector3 pointSave = GameManager.instance.GetSavePoint();
            if(pointSave.x !=0){
                transform.position = new Vector3(pointSave.x, pointSave.y, transform.position.z);
                player.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
                Camera.position = new Vector3(player.position.x, player.position.y, Camera.position.z);
                setCam.targetPosition = new Vector3(player.position.x + decrease, player.position.y, Camera.position.z);
                setCam.initialPosition = Camera.position;
            }
            choiceMap.checkMap = true;
        }
    }
}
