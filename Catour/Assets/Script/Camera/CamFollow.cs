using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private GameObject cat;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        cat = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(cat != null){
            transform.position = new Vector3(cat.transform.position.x - offset, transform.position.y, transform.position.z);
        }
    }
}
