using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnDinosaur : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public GameObject key;
    public float spawnMin;
    public float spawnMax;
    public Controller Control;
    public GameOver gameOver;
    private bool spawn = true;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI congratulationText;
    public bool Loop = false;
    private int score = 0;
    public int targetScore;
    private SceneChange scene;
    // Start is called before the first frame update
    void Start()
    {
        Input.ResetInputAxes();
        scene = FindAnyObjectByType<SceneChange>();
        Control.enableControl(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.isStart()){
            if(Input.GetKeyUp(KeyCode.Space)){
                StartCoroutine(Spawn());
                Control.enableControl(true);
                gameOver.setStart();
            }
        }

        if(gameOver.isGameOver() || gameOver.isEnd()){
            Control.enableControl(false);
            spawn = false;
            if(gameOver.isGameOver()) gameOverText.gameObject.SetActive(true);
            else if(gameOver.isEnd()) congratulationText.gameObject.SetActive(true);
        }

        if(!spawn){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(scene != null && !gameOver.isGameOver()) scene.Return();
                else Restart();
            }
        }
    }

    IEnumerator Spawn(){
        while(spawn){
            float spawnRate = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Obstacles.Count);
            Instantiate(Obstacles[index], new Vector3(transform.position.x, transform.position.y + (Obstacles[index].GetComponent<BoxCollider2D>().size.y * Obstacles[index].transform.localScale.y )/2, transform.position.z), Obstacles[index].transform.rotation);
            
            if(!Loop){
                score++;
                if(score == targetScore){
                    yield return new WaitForSeconds(spawnMax);
                    Instantiate(key, new Vector3(transform.position.x, transform.position.y + (key.GetComponent<BoxCollider2D>().size.y) * key.transform.localScale.y /2, transform.position.z), key.transform.rotation);
                    StopAllCoroutines();
                }
            }
        }
    }

    public void Restart(){
        if(scene != null) scene.Restart();
        else SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue(){
        if(scene != null) scene.Return();
        else SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
