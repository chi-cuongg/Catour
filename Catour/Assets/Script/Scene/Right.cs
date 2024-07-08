using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Right : MonoBehaviour
{
    private GameObject cat;
    private SceneChange scene;
    public ChatText text;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered){
            if(cat.GetComponent<Controller>().isControl()){
                if(Input.GetKeyDown(KeyCode.F)){
                    if(scene.getKey() >= scene.Require()){
                        this.enabled = false;
                        scene.NextScene();
                        triggered = false;
                    }else{
                        text.Text("Có người đang gặp rắc rối, có lẽ mình nên quá đó giúp.");
                    }
                }
            }else{
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.F)){
                    text.endText();
                }
            }
        }

        transform.GetChild(0).gameObject.SetActive(triggered);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        scene = FindAnyObjectByType<SceneChange>();
        triggered = true;
        cat = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        triggered = false;
        cat = null;
    }
}
