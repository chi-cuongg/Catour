using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject Object;
    public Animator animator;
    public SpawnObject spawn;
    private float move;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * move);
        move = speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(move));
        if(transform.position.x - (GetComponent<BoxCollider2D>().size.x * transform.localScale.x)/2 >= (Object.transform.position.x + (((Object.GetComponent<BoxCollider2D>().size.x) * Object.transform.localScale.y))/2)){
            this.enabled = false;
            animator.SetFloat("Speed", 0);
            spawn.setStick();
        }
    }

    public void Move(GameObject Object) {
        this.enabled = true;
        this.Object = Object;
    }
}
