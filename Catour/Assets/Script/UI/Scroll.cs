using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float loopPoint;
    public float speed;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= loopPoint){
            transform.position = startPosition;
        }
        transform.Translate(Vector3.left*speed*Time.deltaTime);
    }
}
