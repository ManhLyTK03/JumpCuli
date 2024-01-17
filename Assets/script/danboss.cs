using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danboss : MonoBehaviour
{
    public float speed = 4.0f; // Điều chỉnh tốc độ di chuyển tại đây
    private Vector3 targetPosition;

    void Start()
    {
        // Khởi tạo vị trí mục tiêu ban đầu
        targetPosition = transform.position;
    }

    void Update()
    {
        // Tính toán vị trí mới mục tiêu
        targetPosition += Vector3.left * speed * Time.deltaTime;

        // Sử dụng lerp để di chuyển mượt mà
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Player")){
            gameObject.SetActive(false);
            checkJump.landed = true;
            Die.checkDie = true;
        }
    }
}
