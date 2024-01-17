using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThrowObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator aniPlayer;
    public GameObject apple; // Đối tượng quả táo
    public Transform throwPoint; // Điểm bắt đầu ném
    public float maxThrowForce = 15.0f; // Lực ném tối đa
    public float throwAngle = 60.0f; // Góc ném cố định
    public float dragDeceleration = 2.5f; // Tốc độ giảm dần khi thả chuột
    public float quickStartForce = 5.0f; // Lực ném ban đầu khi bắt đầu ném nhanh
    public float maxHeight = 1.5f; // Độ cao tối đa của quả táo
    public AudioClip audioClip;
    private AudioSource audioSource;

    private bool isThrowing = false; // Biến kiểm tra xem đang trong trạng thái ném hay không
    private bool isGrounded = true; // Biến kiểm tra xem quả táo đã chạm đất hay chưa
    private Rigidbody2D appleRB; // RigidBody2D của quả táo để điều khiển vận tốc và tình trạng kinematic
    private Vector2 throwDirection; // Hướng ném
    private float throwStartTime; // Thời điểm bắt đầu ném
    private float currentHeight; // Độ cao hiện tại của quả táo

    void Start()
    {
        appleRB = apple.GetComponent<Rigidbody2D>();
        // Tính toán hướng ném dựa trên góc ném
        float throwX = Mathf.Cos(throwAngle * Mathf.Deg2Rad);
        float throwY = Mathf.Sin(throwAngle * Mathf.Deg2Rad);
        throwDirection = new Vector2(throwX, throwY);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (isThrowing)
        {
            // Tính toán thời gian mà nút chuột đã được giữ
            float throwTime = Time.time - throwStartTime;

            // Tính lực ném dựa trên thời gian giữ và lực ném tối đa
            float currentThrowForce = Mathf.Clamp(throwTime * maxThrowForce, 0, maxThrowForce);

            // Áp dụng lực ném
            appleRB.velocity = throwDirection * (quickStartForce + currentThrowForce);

            if (apple.transform.position.y - currentHeight > maxHeight)
            {
                isThrowing = false;
            }
        }

        if (!isThrowing)
        {
            // Áp dụng tốc độ giảm dần
            appleRB.velocity -= throwDirection * dragDeceleration * Time.deltaTime;
            if(appleRB.velocity.y < 1f){
                aniPlayer.SetBool("jump", false);
            }

            // Kiểm tra nếu vận tốc trở nên rất nhỏ, sau đó đặt nó thành không
            if (checkJump.landed)
            {
                isGrounded = true; // Đánh dấu rằng quả táo đã chạm đất
                if(!checkJump.checkIce){
                    appleRB.velocity = new Vector2(0.0f,appleRB.velocity.y);
                }
                else{
                    // appleRB.velocity += new Vector2(appleRB.velocity.x * Time.deltaTime * 10f, 0f);
                }
            }
        }
    }    
    public void OnPointerDown(PointerEventData eventData){
        if (isGrounded)
        {
            currentHeight = throwPoint.position.y;
            isGrounded = false;
            isThrowing = true;
            checkJump.landed = false;
            aniPlayer.SetBool("jump", true);
            throwStartTime = Time.time;
            // Áp dụng lực ném ban đầu nhanh hơn
            appleRB.velocity = throwDirection * quickStartForce;
            audioSource.Play();
        }
    }
    public void OnPointerUp(PointerEventData eventData){
        isThrowing = false;
    }
}