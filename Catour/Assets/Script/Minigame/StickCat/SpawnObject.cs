using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnObject : MonoBehaviour
{
    public GameObject Object;
    private GameObject Object2;
    private bool nextObject = true;
    private float position = 0;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextObject){
            Object2.GetComponentInChildren<StickController>().enabled = true;
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
}
