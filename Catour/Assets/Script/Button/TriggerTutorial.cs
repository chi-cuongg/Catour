using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    public Canvas tutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.GetKeyDown(KeyCode.F)){
            tutorial.gameObject.SetActive(true);
        }
    }
}
