using UnityEngine;

public class BossController : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    public GameObject bulletPrefab; // Prefab của viên đạn
    public float fireRate = 3.0f; // Tốc độ bắn (1 viên đạn/s)
    public Transform FirePosition;
    public float DestroyDan = 2.5f;
    // Khoảng cách tối thiểu để phát âm thanh
    public float minDistance = 20f;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    private void OnEnable()
    {
        InvokeRepeating("FireBullet", 0f, fireRate);
    }

    private void OnDisable()
    {
        CancelInvoke("FireBullet");
    }

    private void FireBullet()
    {
        // Kiểm tra khoảng cách giữa người nghe âm và vật
        float distance = Vector2.Distance(transform.position, Camera.main.transform.position);
        // Nếu khoảng cách nhỏ hơn khoảng cách tối thiểu, phát âm thanh
        if (distance < minDistance)
        {
            audioSource.Play();
        }
        // Tạo một và đặt vị trí bắn ở vị trí của con boss
        GameObject bullet = Instantiate(bulletPrefab, FirePosition.position, Quaternion.identity);
        // Hủy viên đạn sau một thời gian nếu cần
        Destroy(bullet, DestroyDan);
    }
}
