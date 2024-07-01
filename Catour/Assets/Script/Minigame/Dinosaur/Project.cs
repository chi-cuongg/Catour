using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    public float speed;
    public float boundary;
    private SpawnDinosaur spawn;
    private GameOver gameOver;
    // Start is called before the first frame update
    void Awake()
    {
        spawn = FindAnyObjectByType<SpawnDinosaur>();
        gameOver = FindAnyObjectByType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver.isGameOver()){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if(transform.position.x <= boundary){
                Destroy(gameObject);
                spawn.Score();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        gameOver.setGameOver();
    }
}
