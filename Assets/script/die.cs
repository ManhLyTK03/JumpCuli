using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public static bool boolDie;
    public Animator aniPlayer;
    public Transform Camera;
    public Transform save;
    public Transform player;
    public static bool checkDie;
    public GameObject[] bosses;
    
    void Start(){
        checkDie = false;
        bosses = GameObject.FindGameObjectsWithTag("boss");
        boolDie = false;
    }
    void Update(){
        if(checkDie){
            checkDie = false;
            playerDie();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) // Sử dụng CompareTag để kiểm tra tag
        {
            playerDie();
        }
    }
    void playerDie(){
        boolDie = true;
        checkJump.landed = false;
        player.position = new Vector3(save.position.x, save.position.y, player.position.z);
        Camera.position = new Vector3(player.position.x, player.position.y, Camera.position.z);
        aniPlayer.SetBool("die", true);
        // Gọi phương thức với độ trễ 1 giây
        Invoke("SetdieAfterDelay", 1.0f);
        foreach (GameObject boss in bosses){
            boss.SetActive(true);
        }
    }

    // Phương thức sẽ được gọi sau độ trễ
    void SetdieAfterDelay()
    {
        checkJump.landed = true;
        boolDie = false;
        aniPlayer.SetBool("die", false);
    }
}
