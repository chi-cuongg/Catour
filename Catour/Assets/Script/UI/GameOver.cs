using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool start = true;
    private bool gameOver = false;
    private bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStart(){
        start = false;
    }

    public bool isStart(){
        return start;
    }

    public void setGameOver(){
        gameOver = true;
    }

    public bool isGameOver(){
        return gameOver;
    }

    public void setEnd(){
        end = true;
    }

    public bool isEnd(){
        return end;
    }
}
