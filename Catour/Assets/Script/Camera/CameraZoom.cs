using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float speed = 5;
    private float minZoom;
    public float maxZoom = 10;
    private Camera cam;
    private float initialSize;
    private float newSize;
    private float initialPosY;
    private float initialBottomY;
    private bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();

        initialSize = cam.orthographicSize;
        initialPosY = cam.transform.position.y;

        minZoom = initialSize;
        newSize = initialSize;
        initialBottomY = initialPosY - initialSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger){
            if(cam != null){
                newSize += speed * Time.deltaTime;
                newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

                float newBottomY = initialBottomY;
                float newPosY = newBottomY + newSize;

                cam.orthographicSize = newSize;
                cam.transform.position = new Vector3(cam.transform.position.x, newPosY, cam.transform.position.z);
            }
        }else{
            if(cam != null){
                newSize -= speed * Time.deltaTime;
                newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

                float newBottomY = initialBottomY;
                float newPosY = newBottomY + newSize;

                cam.orthographicSize = newSize;
                cam.transform.position = new Vector3(cam.transform.position.x, newPosY, cam.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Zoom") trigger = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag =="Zoom") trigger = false;
    }
}
