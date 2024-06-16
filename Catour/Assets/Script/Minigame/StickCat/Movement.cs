using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        this.enabled = false;
        animator.SetFloat("Speed", 0);
    }
}
