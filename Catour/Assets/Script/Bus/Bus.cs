using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    public GameObject busStop;
    public float speed;
    public float waitingTime;
    private float waitedTime;
    public int Scene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= busStop.transform.position.x + 6){
            Move();
        }else{
            waitedTime += Time.deltaTime;
        }

        if(waitedTime >= waitingTime){
            Move();
        }

        if(transform.position.x <= busStop.transform.position.x - 10){
            Destroy(gameObject);
            SceneManager.LoadScene(Scene);
        }
    }

    public void Move(){
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other){
        other.GetComponent<Renderer>().material.color = Color.clear;
    }
}
