using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fishing : MonoBehaviour
{
    public float spawnMin;
    public float spawnMax;
    private bool gameOver = false;
    private bool fish = false;
    private int point = 0;
    public TextMeshProUGUI pointText;
    public Animator Cat;
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "Point: " + point;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(fish){
            if(Input.GetKeyDown(KeyCode.F)){
                point += 1;
                pointText.text = "Point: " + point;
                fish = false;
                Cat.SetBool("Fishing", false);
            }
        }
    }

    IEnumerator Spawn(){
        while(!gameOver){
            float spawnRate = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(spawnRate);
            fish = true;
            Cat.SetBool("Fishing", true);
            yield return new WaitForSeconds(5);
            fish = false;
            Cat.SetBool("Fishing", false);
        }
    }
}
