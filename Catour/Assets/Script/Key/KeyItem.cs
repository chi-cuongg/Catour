using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private bool project = true;
    public float speed;
    private GameOver end;
    // Start is called before the first frame update
    void Awake()
    {
        end = FindAnyObjectByType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(project && !end.isGameOver()){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            end.setEnd();
            project = false;           
        }
    }
}
