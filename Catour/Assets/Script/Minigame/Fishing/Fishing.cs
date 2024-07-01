using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fishing : MonoBehaviour
{
    public Animator Cat;
    public float spawnMin;
    public float spawnMax;
    private float spawnRate;
    private float spawnWait;
    private bool fish = false;
    private bool fishing = false;
    public GameObject attention;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fishing){
            attention.SetActive(fish);
        }else attention.SetActive(false);

        if(Input.GetKeyDown(KeyCode.Space)){
            fishing = !fishing;
            Cat.SetBool("Fishing", fishing);
            
            if(fishing) spawn();
            else fish = false;
        }

        if(spawnRate > 0){
            spawnRate -= Time.deltaTime;
            
        }else{
            if(fishing){
                fish = true;
                if(spawnWait > 0){
                    spawnWait -= Time.deltaTime;
                }else{
                    fish = false;
                    spawn();
                }
            }
        }
    }

    private void spawn(){
        spawnRate = Random.Range(spawnMin, spawnMax);
        spawnWait = Random.Range(spawnMin, spawnMax);
    }
}
