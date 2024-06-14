using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Music : MonoBehaviour
{
    public List<GameObject> Buttons;
    public float spawnMax;
    private bool gameOver = false;
     private int point = 0;
    public TextMeshProUGUI pointText;
    private GameObject other;
    private bool Triggered = false;
    // public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {  
        pointText.text = "Point: " + point;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(Triggered){
            switch(other.name){
                case "Up(Clone)":
                    if(Input.GetKeyDown(KeyCode.W)){
                        Destroy(other);
                        pointSet(2);
                    }else if(Input.anyKeyDown){
                        Destroy(other);
                        pointSet(0);
                    }break;
                case "Down(Clone)":
                    if(Input.GetKeyDown(KeyCode.S)){
                        Destroy(other);
                        pointSet(2);
                    }else if(Input.anyKeyDown){
                        Destroy(other);
                        pointSet(0);
                    }break;
                case "Left(Clone)":
                    if(Input.GetKeyDown(KeyCode.A)){
                        Destroy(other);
                        pointSet(2);
                    }else if(!Input.anyKeyDown){
                        Destroy(other);
                        pointSet(0);
                    }break;
                case "Right(Clone)":
                    if(Input.GetKeyDown(KeyCode.D)){
                        Destroy(other);
                        pointSet(2);
                    }else if(Input.anyKeyDown){
                        Destroy(other);
                        pointSet(0);
                    }break;
            }
        }
    }

    IEnumerator Spawn(){
        while(!gameOver){
            float spawnRate = Random.Range(1, spawnMax);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Buttons.Count);
            switch(index){
                case 0:
                    Instantiate(Buttons[index], new Vector3(-6, 5.55f, 0), Buttons[index].transform.rotation);
                    break;
                case 1:
                    Instantiate(Buttons[index], new Vector3(-2, 5.55f, 0), Buttons[index].transform.rotation);
                    break;
                case 2:
                    Instantiate(Buttons[index], new Vector3(2, 5.55f, 0), Buttons[index].transform.rotation);
                    break;
                case 3:
                    Instantiate(Buttons[index], new Vector3(6, 5.55f, 0), Buttons[index].transform.rotation);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Triggered = true;
        this.other = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        Triggered = false;            
        Destroy(this.other);
        pointSet(-1);

    }

    private void pointSet(int point){
        this.point += point;
        pointText.text = "Point: " + this.point;
    }
}
