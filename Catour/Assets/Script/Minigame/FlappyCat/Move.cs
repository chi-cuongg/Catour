using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float boundary;
    private SpawnFlappy spawn;
    private GameOver gameOver;
    // Start is called before the first frame update
    void Start()
    {
        spawn = FindAnyObjectByType<SpawnFlappy>();
        gameOver = FindAnyObjectByType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver.isGameOver() && !gameOver.isEnd()){
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if(transform.position.x <= boundary){
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameOver.setGameOver();
        }
    }
}
