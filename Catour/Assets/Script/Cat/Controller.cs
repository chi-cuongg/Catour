using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool Control = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableControl(bool Control){
        transform.gameObject.GetComponent<Animator>().enabled = Control;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.Control = Control;
    }

    public bool isControl(){
        return Control;
    }
}
