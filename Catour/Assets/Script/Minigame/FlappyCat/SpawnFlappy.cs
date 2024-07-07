using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnFlappy : MonoBehaviour
{
    public GameObject Obstacles;
    public GameObject key;
    public float spawnMin;
    public float spawnMax;
    public float offset;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.isStart()){
            if(Input.GetKeyUp(KeyCode.Space)){
                StartCoroutine(Spawn());
                Control.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Control.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                Control.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                Control.enableControl(true);
                Control.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Control.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                gameOver.setStart();
            }
        }

        if(gameOver.isGameOver() || gameOver.isEnd()){
            if(Control != null){ 
                Control.enableControl(false);
            }spawn = false;

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
            float off = Random.Range(-offset, offset);
            Instantiate(Obstacles, new Vector3(transform.position.x, transform.position.y + off, transform.position.z), Obstacles.transform.rotation);
            
            if(!Loop){
                score++;
                if(score == targetScore){ 
                    Instantiate(key, new Vector3(transform.position.x, transform.position.y + off, transform.position.z), Obstacles.transform.rotation);
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
