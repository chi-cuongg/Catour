using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    private SceneChange scene;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        scene = FindAnyObjectByType<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).gameObject.SetActive(triggered);
        if(triggered){ 
            if(Input.GetKeyDown(KeyCode.F)){
                if(scene != null) scene.NextScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        triggered = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        triggered = false;
    }
}
