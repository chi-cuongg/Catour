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
    public int targetScore;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.isGameOver() || gameOver.isEnd()){
            Control.enableControl(false);
            spawn = false;
            if(gameOver.isGameOver()) gameOverText.gameObject.SetActive(true);
            else if(gameOver.isEnd()) congratulationText.gameObject.SetActive(true);
        }
    }

    public void Score(){
        if(!Loop){
            score++;
            if(score == targetScore-1){
                gameOver.setVictory();
            }
        }
    }

    IEnumerator Spawn(){
        while(spawn){
            if(gameOver.isVictory()){
                yield return new WaitForSeconds(spawnMax);
                Instantiate(key, new Vector3(transform.position.x, transform.position.y + (key.GetComponent<BoxCollider2D>().size.y)/2, transform.position.z), key.transform.rotation);
                StopAllCoroutines();
            }

            float spawnRate = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Obstacles.Count);
            Instantiate(Obstacles[index], new Vector3(transform.position.x, transform.position.y + (Obstacles[index].GetComponent<BoxCollider2D>().size.y)/2, transform.position.z), Obstacles[index].transform.rotation);
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
