using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ButtonTutorial : MonoBehaviour
{
    public GameObject[] KeyButton; 
    private KeyCode[] key = {KeyCode.D, KeyCode.A, KeyCode.Space};
    private int step = -1;
    private GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Trigger(GameObject cat){
        this.cat = cat;
        step = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(step >= 0 && step < key.Length){
            Debug.Log(KeyButton[step]);
            Destroy(GameObject.FindWithTag("Button"));
            Instantiate(KeyButton[step], cat.transform.position + new Vector3(0, 1.5f, 0), KeyButton[step].transform.rotation);
            if(Input.GetKey(key[step])){ 
                step++;
            }
        }else Destroy(GameObject.FindWithTag("Button"));
    }
}
