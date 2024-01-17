using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float timeHide = 1.0f;
    public bool kill = true;
    Animator ani;
    bool checkBoss;
    private Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        checkBoss = true;
    }
    void OnTriggerEnter2D(Collider2D col){
        if(checkBoss){
            if (col.gameObject.CompareTag("win") && kill){
                checkJump.landed = true;
                ani.SetBool("die", true);
                checkBoss = false;
                Invoke("HideGameObject", timeHide);
                Invoke("check", timeHide);
            }
            else if (col.gameObject.CompareTag("lost"))
            {
                Die.checkDie = true;
                checkBoss = false;
                Invoke("check", timeHide);
            }
        }
    }
    private void HideGameObject()
    {
        gameObject.SetActive(false);
    }
    private void check()
    {
        checkBoss = true;
    }
}
