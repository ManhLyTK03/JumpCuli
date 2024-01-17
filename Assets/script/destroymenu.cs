using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroymenu : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("backMenu")){
            Destroy(col.gameObject);
        }
    }
}
