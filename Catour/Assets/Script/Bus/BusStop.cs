using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    public GameObject bus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.GetComponent<PlayerMovement>().isControl()){
            if(Input.GetKeyDown(KeyCode.F)){
                Instantiate(bus, new Vector3(transform.position.x + 10, transform.position.y - 1, transform.position.z), transform.rotation, gameObject.transform);
                other.gameObject.GetComponent<PlayerMovement>().disableControl();
            }
        }
    }
}
