using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minZoom = 20f;
    public float maxZoom = 100f;
    
    // Update is called once per frame
    void Update()
    {
        // Get the scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Check if the camera is orthographic or perspective
        if (GetComponent<Camera>().orthographic)
        {
            // Orthographic camera: adjust the orthographic size
            float newSize = GetComponent<Camera>().orthographicSize - scrollInput * zoomSpeed;
            GetComponent<Camera>().orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        }
        else
        {
            // Perspective camera: adjust the field of view
            float newFov = GetComponent<Camera>().fieldOfView - scrollInput * zoomSpeed;
            GetComponent<Camera>().fieldOfView = Mathf.Clamp(newFov, minZoom, maxZoom);
        }
    }
}
