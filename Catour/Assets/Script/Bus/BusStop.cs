using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    public GameObject bus;
    private bool triggered = false;
    private GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered){
            if(cat.GetComponent<Controller>().isControl()){
                if(Input.GetKeyDown(KeyCode.F)){
                    transform.GetChild(0).gameObject.SetActive(false);
                    Instantiate(bus, new Vector3(transform.position.x + 10, transform.position.y - 1, transform.position.z), transform.rotation, gameObject.transform);
                    cat.GetComponent<Controller>().enableControl(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        triggered = true;
        cat = other.gameObject;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        triggered = false;
        cat = null;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
