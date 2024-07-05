using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static GameObject scene;
    private int current;
    public int minigame;
    private List<GameObject> data = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if(scene == null){
            scene = this.gameObject;
            DontDestroyOnLoad(scene);
        }else Destroy(this.gameObject);
        
        
        current = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(){
        SceneManager.LoadSceneAsync(current + 1);
    }

    public void MiniGame(){
        SceneManager.LoadSceneAsync(minigame, LoadSceneMode.Additive);

        foreach(GameObject g in GameObject.FindObjectsOfType<GameObject>()){
            if(g.tag != "Scene"){
                g.SetActive(false);
                data.Add(g);
            }
        }
    }

    public void Return(){
        SceneManager.UnloadSceneAsync(minigame);

        foreach(GameObject g in data){
            g.SetActive(true);
        }
    }
}
