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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.isGameOver() || gameOver.isEnd()){
            if(Control != null){ 
                Control.enableControl(false);
                Control.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }spawn = false;

            if(gameOver.isGameOver()) gameOverText.gameObject.SetActive(true);
            else if(gameOver.isEnd()) congratulationText.gameObject.SetActive(true);

            this.enabled = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
