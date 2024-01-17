using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermenu : MonoBehaviour
{
    public static bool runmenu = false;
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Animator>();
        Invoke("ChangeAnimatorState", 5f);
    }
    void ChangeAnimatorState()
    {
        player.SetBool("run", true);
        runmenu = true;
    }
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("OnCollisionEnter2D");
        buttonmenu.jump = false;
    }
}
