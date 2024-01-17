using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhim : MonoBehaviour
{
    private AudioSource audioSource;
    public Transform playerPosition;
    public Rigidbody2D player;
    public float moveSpeed = 2.0f;
    public float moveDistance = 10.0f;
    public float pauseTime = 1.0f; // Thời gian dừng ở hai đầu
    // Khoảng cách tối thiểu để phát âm thanh
    public float minDistance = 20f;
    public float timeHide = 5f;
    public float time = 10.0f;
    public float jump;

    private float distanceTraveled = 0;
    private bool movingRight = true;
    private float pauseTimer = 0;
    public bool direction;
    private bool nhimDie;
    SpriteRenderer spriteRenderer;
    Animator ani;

    void Start()
    {
        nhimDie = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(playerPosition.position.x > transform.position.x + 5f){
            nhimDie = false;
            ani.SetBool("nhimin", false);
        }
        if(!nhimDie){
            // Kiểm tra khoảng cách giữa người nghe âm và vật
            float distance = Vector2.Distance(transform.position, Camera.main.transform.position);
            // Nếu khoảng cách nhỏ hơn khoảng cách tối thiểu, phát âm thanh
            if (distance < minDistance)
            {
                if(!audioSource.isPlaying){
                    audioSource.Play();
                }
            }
            else{
                if(audioSource.isPlaying){
                    audioSource.Stop();
                }
            }
            if(audioSource.isPlaying){
                audioSource.volume = 1f - (distance / minDistance);
            }
            if (pauseTimer > 0)
            {
                // Dừng lại ở hai đầu khoảng cách
                pauseTimer -= Time.deltaTime;
            }
            else
            {
                if (movingRight)
                {
                    if(direction){
                        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                    }
                    else{
                        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                    }
                    distanceTraveled += moveSpeed * Time.deltaTime;
                }
                else
                {
                    if(direction){
                        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                    }
                    else{
                        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
                    }
                    distanceTraveled += moveSpeed * Time.deltaTime;
                }

                if (distanceTraveled >= moveDistance)
                {
                    movingRight = !movingRight;
                    distanceTraveled = 0;
                    pauseTimer = pauseTime; // Bắt đầu đếm thời gian dừng lại
                    // Đảo hướng sprite khi đổi hướng di chuyển
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("win")){
            checkJump.landed = true;
            ani.SetBool("nhimin", true);
            nhimDie = true;
            player.velocity = new Vector2(0.0f, jump);
        }
    }
}
