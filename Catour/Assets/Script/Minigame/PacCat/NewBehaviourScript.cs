using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int numToSpawn = 25;
    public float spawnOffSet = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Node") ;
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                GameObject clone = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y, 0), Quanternion.identity);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
