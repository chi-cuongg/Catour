using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    private GameObject Object1;
    private GameObject Object2;
    private bool nextObject = true;
    private float position = 0;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        Object2.transform.GetChild(1).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(nextObject){
            Object1 = Object2;
            position += Random.Range(4, 6);
            Spawn();
            nextObject = false;
        }
    }

    public void Spawn(){
        Object2 = Instantiate(Object, new Vector3(position, 0, 0), Object.transform.rotation);
    }

    public void Next(){
        nextObject = true;
    }

    public void setGameOver(){
        gameOver = true;
    }

    public bool isGameOver(){
        return gameOver;
    }

    public void setStick(){
        Object1.transform.GetChild(1).gameObject.SetActive(true);
    }
}
