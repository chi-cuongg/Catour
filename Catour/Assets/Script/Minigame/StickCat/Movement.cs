using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameOver gameOver;
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
        move = speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(move));
        transform.Translate(Vector3.right * move);

        if(transform.position.x - (GetComponent<BoxCollider2D>().size.x * transform.localScale.x)/2 - 0.1f >= (Object.transform.position.x + (((Object.GetComponent<BoxCollider2D>().size.x) * Object.transform.localScale.y))/2)){
            animator.SetFloat("Speed", 0);
            spawn.setStick();
            this.enabled = false;
        }

        if(gameOver.isEnd()){
            animator.enabled = false;
            this.enabled = false;
        }
    }

    public void Move(GameObject Object) {
        this.enabled = true;
        this.Object = Object;
    }

    private void OnDestroy() {
        gameOver.setGameOver();
    }
}
