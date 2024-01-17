using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Rigidbody2D player;
    public float jumpForce = 10f;
    public float maxJumpTime = 2f;
    public float jumpAngleDegrees = 45f; // Góc nhảy
    public float initialVelocity = 5f; // Vận tốc ban đầu khi thả chuột

    private bool isJumping = false;
    private float jumpTime = 0f;

    void Update()
    {
        // Khi người dùng giữ chuột
        if (isJumping)
        {
            jumpTime += Time.deltaTime;

            // Giới hạn thời gian nhảy tối đa
            jumpTime = Mathf.Clamp(jumpTime, 0f, maxJumpTime);
        }
    }

    // Khi người dùng nhấn chuột
    public void OnPointerDown(PointerEventData eventData)
    {
        isJumping = true;
        jumpTime = 0f;
    }

    // Khi người dùng nhả chuột
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Tính toán độ cao dựa trên thời gian giữ chuột
        float jumpHeight = jumpForce * Mathf.Clamp01(jumpTime / maxJumpTime);

        // Góc nhảy (quy đổi thành radian)
        float jumpAngle = jumpAngleDegrees * Mathf.Deg2Rad;

        // Tính toán thành phần x và y của vận tốc dựa trên góc nhảy
        float jumpVelocityX = Mathf.Cos(jumpAngle);
        float jumpVelocityY = Mathf.Sin(jumpAngle);

        // Thêm vận tốc ban đầu khi thả chuột
        player.velocity = new Vector2(jumpVelocityX, jumpVelocityY) * initialVelocity;

        // Áp dụng vận tốc nhảy cho đối tượng
        player.velocity += new Vector2(jumpVelocityX, jumpVelocityY) * jumpHeight;

        // Đặt lại trạng thái nhảy
        isJumping = false;
        jumpTime = 0f;
    }
}
