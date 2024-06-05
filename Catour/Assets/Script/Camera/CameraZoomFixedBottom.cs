using UnityEngine;

public class CameraZoomWithFixedBottom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minZoom = 20f;
    public float maxZoom = 100f;

    private Camera cam;
    private float initialSize;
    private float initialFov;
    private float initialPosY;
    private float initialBottomY;

    void Start()
    {
        cam = GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("Camera component not found on this GameObject. Please attach this script to a Camera.");
            return;
        }

        if (cam.orthographic)
        {
            initialSize = cam.orthographicSize;
        }
        else
        {
            initialFov = cam.fieldOfView;
        }

        initialPosY = transform.position.y;

        // Tính toán vị trí lề dưới ban đầu
        if (cam.orthographic)
        {
            initialBottomY = initialPosY - cam.orthographicSize;
        }
        else
        {
            float halfHeight = Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad) * Mathf.Abs(transform.position.z);
            initialBottomY = initialPosY - halfHeight;
        }
    }

    void Update()
    {
        if (cam == null) return;

        if (Input.GetKey(KeyCode.I))
        {
            ZoomIn();
        }
        if (Input.GetKey(KeyCode.O))
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        if (cam == null) return;

        if (cam.orthographic)
        {
            float newSize = cam.orthographicSize - zoomSpeed * Time.deltaTime;
            newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

            float newBottomY = initialBottomY;
            float newPosY = newBottomY + newSize;

            cam.orthographicSize = newSize;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
        else
        {
            float newFov = cam.fieldOfView - zoomSpeed * Time.deltaTime;
            newFov = Mathf.Clamp(newFov, minZoom, maxZoom);

            float halfHeight = Mathf.Tan(newFov * 0.5f * Mathf.Deg2Rad) * Mathf.Abs(transform.position.z);
            float newBottomY = initialBottomY;
            float newPosY = newBottomY + halfHeight;

            cam.fieldOfView = newFov;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
    }

    void ZoomOut()
    {
        if (cam == null) return;

        if (cam.orthographic)
        {
            float newSize = cam.orthographicSize + zoomSpeed * Time.deltaTime;
            newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

            float newBottomY = initialBottomY;
            float newPosY = newBottomY + newSize;

            cam.orthographicSize = newSize;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
        else
        {
            float newFov = cam.fieldOfView + zoomSpeed * Time.deltaTime;
            newFov = Mathf.Clamp(newFov, minZoom, maxZoom);

            float halfHeight = Mathf.Tan(newFov * 0.5f * Mathf.Deg2Rad) * Mathf.Abs(transform.position.z);
            float newBottomY = initialBottomY;
            float newPosY = newBottomY + halfHeight;

            cam.fieldOfView = newFov;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        }
    }
}
