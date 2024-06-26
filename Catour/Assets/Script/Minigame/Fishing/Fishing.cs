using System.Collections;
using System.Collections.Generic;
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
    public Sprite[] fishObject;
    private int index ;
    private int rate = 0;
    public int rateUp;
    private Sprite fishobj;
    private bool fish = false;
    private bool fishing = false;
    private bool Continue = true;
    public GameObject attention;
    public FishSprite fishSprite;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        fishing = !fishing;
        Cat.SetBool("Fishing", fishing);

        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(fishing){
            attention.SetActive(fish);
        }else attention.SetActive(false);

        if(Input.GetKeyDown(KeyCode.Space)){
            if(Continue){
                fishing = !fishing;
                Cat.SetBool("Fishing", fishing);
                
                if(fishing){ 
                    fishSprite.gameObject.SetActive(false);
                    text.text = "";

                    spawn();
                }else{ 
                    if(fish){
                        fishSprite.Fish(fishobj);
                        Debug.Log(index);
                        if(index == 3){
                            text.text = "Congratulation!!!";
                            text.color = new Color(255, 255, 0, 255);
                            Continue = false;
                        }else text.text = "Better luck next time!";

                        rate += rateUp;
                        fish = false;
                    }else{
                        text.text = "Oops...";
                    }
                }
            }
        }

        if(spawnRate > 0){
            spawnRate -= Time.deltaTime;
        }else{
            if(fishing){
                fish = true;
                gacha();
                fishobj = fishObject[index];

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

    private void gacha(){
        int choose = Random.Range(0, 100);
        
        if(choose >= 0 && choose < 50 - rate){
            index = 0;
        }else if(choose >= 50 - rate && choose < 80 - rate * 1.5f){
            index = 1;
        }else if(choose >= 80 - rate * 1.5f && choose < 95 - rate){
            index = 2;
        }else if(choose >= 95 - rate && choose < 100){
            index = 3;
        }
    }
}
