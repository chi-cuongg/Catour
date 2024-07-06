using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    public GameObject key;
    private GameObject Object0;
    private GameObject Object1;
    private GameObject Object2;
    private bool nextObject = true;
    private float position = 0;
    public float spawnMin;
    public float spawnMax;
    private int score = -1;
    public int targetScore;
    public bool Loop = false;
    private bool Return = false;
    public GameOver gameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victoryText;
    private SceneChange scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = FindAnyObjectByType<SceneChange>();

        Spawn();
        Object1 = Object2;
        setStick();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextObject){
            Object0 = Object1;
            Object1 = Object2;

            position += Random.Range(spawnMin, spawnMax);
            Spawn();
            if(!Loop){
                score++;
                if(score == targetScore-1) Key();
            }
            
            nextObject = false;
        }

        if(gameOver.isGameOver()){
            gameOverText.gameObject.SetActive(true);
            Return = true;
        }

        if(gameOver.isEnd()){
            victoryText.gameObject.SetActive(true);
            Return = true;
        }

        if(Return){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(scene != null) scene.Return();
                else Restart();
            }
        }
    }

    public void Spawn(){
        Object2 = Instantiate(Object, new Vector3(position, 0, 0), Object.transform.rotation);
    }

    public void Next(){
        if(!Loop){
            if(score < targetScore-1){
                nextObject = true;
            }
        }else nextObject = true;
    }

    public void setStick(){
        Destroy(Object0);
        
        Object1.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Key(){
        Vector3 dest = new Vector3(Object2.transform.position.x, Object2.transform.position.y + (Object2.GetComponentInChildren<BoxCollider2D>().size.y) / 2 + 0.5f, Object2.transform.position.z);
        Instantiate(key, dest, key.transform.rotation);
    }

    public void Restart(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
