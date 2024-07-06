using UnityEngine;

public class MoveAndRandomizeSpeed : MonoBehaviour
{
    public float minSpeed = 1f; // Tốc độ tối thiểu
    public float maxSpeed = 100f; // Tốc độ tối đa
    private float currentSpeed; // Tốc độ hiện tại
    public float resetPosition = -10f; // Vị trí reset khi đi ra ngoài camera
    public float startPosition = 10f; // Vị trí bắt đầu khi loop lại

    void Start()
    {
        // Khởi tạo tốc độ ban đầu
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // Di chuyển GameObject về bên trái với tốc độ hiện tại
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        // Kiểm tra nếu GameObject đi ra khỏi camera
        if (transform.position.x < resetPosition)
        {
            // Đặt lại vị trí của GameObject
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);

            // Sinh ra một tốc độ mới
            currentSpeed = Random.Range(minSpeed, maxSpeed);
        }
    }
}
