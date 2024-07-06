using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    public float speed;
    public float boundary;
    private SpawnObstacles spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = FindAnyObjectByType<SpawnObstacles>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawn.isGameOver()){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if(transform.position.x <= boundary){
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
            spawn.setGameOver();
    }
}
