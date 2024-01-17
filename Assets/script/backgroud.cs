using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform[] backgrounds; // Mảng chứa các lớp nền
    public float[] parallaxScales; // Tỷ lệ parallax (càng xa, càng nhỏ)

    public Transform cam; // Tham chiếu đến camera chính

    private Vector3 previousCamPos; // Vị trí trước của camera

    void Start()
    {
        previousCamPos = cam.position;
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Tính toán sự dịch chuyển của nền dựa trên sự di chuyển của camera
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Tạo một vị trí mới cho nền
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Tạo một vị trí mới với tọa độ Y không thay đổi
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Di chuyển nền đến vị trí mới
            backgrounds[i].position = backgroundTargetPos;
        }

        // Cập nhật lại vị trí trước của camera
        previousCamPos = cam.position;
    }
}
