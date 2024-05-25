using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Play(int Scene){
        SceneManager.LoadScene(Scene);
    }

    public void Quit(){
        Application.Quit();
    }
}
