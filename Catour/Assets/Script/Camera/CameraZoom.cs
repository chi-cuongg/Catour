using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float minZoom;
    public float maxZoom = 100f;
    private Camera cam;
    private float initialSize;
    private float initialPosY;
    private float initialBottomY;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();

        initialSize = cam.orthographicSize;
        initialPosY = cam.transform.position.y;

        minZoom = initialSize;
        initialBottomY = initialPosY - initialSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(cam != null){
            float newSize = maxZoom;

            float newBottomY = initialBottomY;
            float newPosY = newBottomY + newSize;

            cam.orthographicSize = newSize;
            cam.transform.position = new Vector3(cam.transform.position.x, newPosY, cam.transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(cam != null){
            float newSize = minZoom;

            float newBottomY = initialBottomY;
            float newPosY = newBottomY + newSize;
            Debug.Log(newPosY + " " + initialPosY + " position");
            Debug.Log(newBottomY + " " + initialBottomY + " bottom");
            Debug.Log(newSize + " " + initialSize + " size");

            cam.orthographicSize = newSize;
            cam.transform.position = new Vector3(cam.transform.position.x, newPosY, cam.transform.position.z);
        }    
    }
}
