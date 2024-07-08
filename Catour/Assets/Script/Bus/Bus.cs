using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    private GameObject busStop;
    public float speed;
    public float waitingTime;
    private float waitedTime;
    private SceneChange scene;

    // Start is called before the first frame update
    void Start()
    {
        busStop = GameObject.FindGameObjectWithTag("Bus Stop");
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= busStop.transform.position.x - 0.3){
            Move();
        }else{
            waitedTime += Time.deltaTime;
        }

        if(waitedTime >= waitingTime){
            Move();
        }

        if(transform.position.x <= busStop.transform.position.x - 15){
            Destroy(gameObject);
            if(scene != null) scene.NextScene();
        }
    }

    public void Move(){
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other){
        other.GetComponent<Renderer>().material.color = Color.clear;
    }
}
