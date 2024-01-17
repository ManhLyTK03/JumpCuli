using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkJump : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public static bool landed;
    public static bool checkIce;
    // Start is called before the first frame update
    void Start()
    {
        landed = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("ice")) // Sử dụng CompareTag để kiểm tra tag
        {
            if(!Die.boolDie){
                landed = true;
            }
            if (col.gameObject.CompareTag("ice"))
            {
                checkIce = true;
            }
        }
        if (col.gameObject.CompareTag("boss"))
        {
            audioSource.Play();
        }
    }
}
