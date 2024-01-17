using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFl : MonoBehaviour
{
    public static bool startFL;
    public Transform Player;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
        startFL = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startFL){
            Vector3 camNew = Player.position + setCam.distance;
            transform.position = Vector3.Lerp(transform.position,camNew,smooth*Time.deltaTime);
        }
    }
}
