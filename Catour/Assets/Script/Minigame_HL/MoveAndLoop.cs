using UnityEngine;

public class MoveAndLoop : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển
    public float resetPosition = -10f; // Vị trí reset khi đi ra ngoài camera
    public float startPosition = 10f; // Vị trí bắt đầu khi loop lại

    void Update()
    {
        // Di chuyển GameObject về bên trái
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Kiểm tra nếu GameObject đi ra khỏi camera
        if (transform.position.x < resetPosition)
        {
            // Đặt lại vị trí của GameObject
            Vector3 newPosition = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
