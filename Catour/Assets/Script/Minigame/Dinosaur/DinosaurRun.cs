using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRun : MonoBehaviour
{
    public Controller Control;
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 2f;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Control.isControl()){
            animator.SetFloat("Speed", Mathf.Abs(runSpeed));

            if (Input.GetButtonDown("Jump"))
            {
                if(controller.groundCheck()){
                    jump = true;
                    animator.SetBool("IsJumping", true);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if(Control.isControl()){
            controller.Move(runSpeed, jump); 
            jump = false;
        }
    }
    
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
