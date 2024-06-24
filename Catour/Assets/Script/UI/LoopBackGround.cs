using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackGround : MonoBehaviour
{
    public float speed;
    private Vector3 start;
    private float width;
    private SpawnObstacles spawn;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        width = GetComponent<BoxCollider2D>().size.x * transform.localScale.x / 2;
        spawn = FindAnyObjectByType<SpawnObstacles>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawn.isGameOver()){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
                if(transform.position.x <= start.x - width){
                    transform.position = start;
                }
        }
    }
}
