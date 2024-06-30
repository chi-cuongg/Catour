using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnDinosaur : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public float spawnMin;
    public float spawnMax;
    public Controller Control;
    public GameOver gameOver;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.isGameOver()){
            Control.enableControl(false);
            gameOverText.gameObject.SetActive(true);
        }
    }

    IEnumerator Spawn(){
        while(!gameOver.isGameOver()){
            float spawnRate = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Obstacles.Count);
            Instantiate(Obstacles[index], new Vector3(14, -3.12f + (Obstacles[index].GetComponent<BoxCollider2D>().size.y)/2, 0), Obstacles[index].transform.rotation);
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
