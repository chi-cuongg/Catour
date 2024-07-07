using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static GameObject scene;
    private int minigame;
    private List<GameObject> data = new List<GameObject>();
    private int key = 0;
    private int require = 1;
    public Animator trans;
    // Start is called before the first frame update
    void Start()
    {
        if(scene == null){
            scene = this.gameObject;
            DontDestroyOnLoad(scene);
            trans.enabled = true;
        }else Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(){
        require++;
        StartCoroutine(Next());
    }

    IEnumerator Next(){
        trans.SetBool("Trigger", true);
        yield return new WaitForSeconds(1);

        if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);

        trans.SetBool("Trigger", false);
    }

    public void MiniGame(int minigame){
        if(minigame >= 0){
            this.minigame = minigame;
            StartCoroutine(Load());
        }
    }
    IEnumerator Load(){
        trans.SetBool("Trigger", true);
        yield return new WaitForSeconds(1);

        AsyncOperation load = SceneManager.LoadSceneAsync(minigame, LoadSceneMode.Additive);
        foreach(GameObject g in GameObject.FindObjectsOfType<GameObject>()){
            if(g.tag != "Scene"){
                g.SetActive(false);
                data.Add(g);
            }
        }

        yield return load;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(minigame));

        trans.SetBool("Trigger", false);
    }

    public void Return(){
        StartCoroutine(Unload());
    }

    IEnumerator Unload(){
        trans.SetBool("Trigger", true);
        yield return new WaitForSeconds(1);

        foreach(GameObject g in data){
            if(g != null) g.SetActive(true);
        }

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        trans.SetBool("Trigger", false);
    }

    public void Restart(){
        Return();
        MiniGame(minigame);
    }

    public void setKey(){
        key++;
    }

    public int getKey(){
        return key;
    }

    public int Require(){
        return require;
    }
}
