using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmenu : MonoBehaviour
{
    public Animator player;
    public float speed;
    public Transform swap;
    public GameObject back;
    void Update(){
        if(playermenu.runmenu){
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if(transform.position.x > -0.01f && transform.position.x < 0.01f){
            GameObject backswap = Instantiate(back, new Vector3(swap.position.x,transform.position.y, transform.position.z) , Quaternion.identity);
        }
    }
}
