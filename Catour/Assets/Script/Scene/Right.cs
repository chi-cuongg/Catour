using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Right : MonoBehaviour
{
    private SceneChange scene;
    private bool triggered = false;
    public ChatText text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).gameObject.SetActive(triggered);
        if(triggered){ 
            if(Input.GetKeyDown(KeyCode.F)){
                if(scene.getKey() >= scene.Require()){
                    this.enabled = false;
                    if(scene != null) scene.NextScene();
                    triggered = false;
                }else{
                    text.Text();
                    triggered = false;
                }
            }
        }
        
        if(text.isText()){
            if(Input.GetKeyDown(KeyCode.Space)){
                text.endText();
                triggered = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        scene = FindAnyObjectByType<SceneChange>();
        triggered = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        triggered = false;
    }
}
