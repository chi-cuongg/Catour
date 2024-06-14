using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public float spawnMin;
    public float spawnMax;
    private bool gameOver = false;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn(){
        while(!gameOver){
            float spawnRate = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Obstacles.Count);
            Instantiate(Obstacles[index], new Vector3(14, -3.12f + (Obstacles[index].GetComponent<BoxCollider2D>().size.y)/2, 0), Obstacles[index].transform.rotation);
        }
    }

    public void setGameOver(){
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
    }

    public bool isGameOver(){
        return gameOver;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
