using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStop : MonoBehaviour
{
    public CamFollow cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        cam.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(cam != null) cam.enabled = true;
    }
}
