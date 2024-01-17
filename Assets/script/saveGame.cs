using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class saveGame : MonoBehaviour
{
    public Transform save;
    public int intSave;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Player")){
            save.position = transform.position;
            if(GameManager.instance.GetHighScore() <= intSave){
                GameManager.instance.SetHighScore(intSave);
                GameManager.instance.SetSavePoint(transform.position);
            }
            Destroy(gameObject);
        }
    }
}
