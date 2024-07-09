using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    private SceneChange scene;
    void Start() {
        scene = FindAnyObjectByType<SceneChange>();    
    }

    public void Mode(GameObject mode){
        this.gameObject.SetActive(false);
        mode.SetActive(true);
    }

    public void Play(int Scene){
        SceneManager.LoadScene(Scene);
    }

    public void Quit(){
        SceneManager.LoadSceneAsync(0);
        if(scene != null) scene.Reset();
    }
}