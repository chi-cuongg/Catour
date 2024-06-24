using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRun : MonoBehaviour
{
    public SpawnObstacles spawn;
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 2f;
    bool jump = false;
    private const float idleThreshold = 5f;
    private bool Control = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn.isGameOver()) this.enabled = false;
        animator.SetFloat("Speed", Mathf.Abs(runSpeed));

        if (Input.GetButtonDown("Jump"))
        {
            if(controller.groundCheck()){
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void disableControl(){
        Control = false;
    }

    public bool isControl(){
        return Control;
    }

    void FixedUpdate()
    {
        if(Control){
            controller.Move(runSpeed, false, jump); 
            jump = false;
        }
    }
}
