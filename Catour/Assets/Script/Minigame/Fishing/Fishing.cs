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
    public float waitingTime;
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
            Debug.Log(fish);
            attention.SetActive(fish);
        }else attention.SetActive(false);

        if(Input.GetKeyDown(KeyCode.Space)){
            fishing = !fishing;
            Cat.SetBool("Fishing", fishing);
            if(fishing) StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn(){
        float spawnRate = Random.Range(spawnMin, spawnMax);
        Debug.Log(spawnRate);
        yield return new WaitForSeconds(spawnRate);
        fish = true;
        yield return new WaitForSeconds(waitingTime);
        fish = false;
    }
}
