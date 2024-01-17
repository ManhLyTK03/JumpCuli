using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public int intSave;
    // Hàm này được gọi khi có sự va chạm với Collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (other.CompareTag("Player"))
        {
            // Chuyển đến scene mới
            SceneManager.LoadScene("lever2");
            if(GameManager.instance.GetHighScore() < intSave){
                GameManager.instance.SetHighScore(intSave);
                GameManager.instance.SetSavePoint(transform.position);
            }
        }
    }
}
