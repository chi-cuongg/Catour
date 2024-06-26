using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controller Control;
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 2f;
    float horizontalMove = 0f;
    bool jump = false;
    private float idleTime = 0f;
    private bool isIdle = false;
    private const float idleThreshold = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Control.isControl()){
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                if(controller.groundCheck()){
                    jump = true;
                    animator.SetBool("IsJumping", true);
                }
            }

            if(Mathf.Abs(horizontalMove) > 0 || jump == true)
            {
                idleTime = 0f;
                isIdle = false;
            }
            else
            {
                idleTime += Time.deltaTime;
                if (idleTime >= idleThreshold) 
                {
                    isIdle = true;
                }
            }

            animator.SetBool("IsIdle", isIdle);
            animator.SetFloat("IdleTime", idleTime);
        }
    }

    void FixedUpdate()
    {
        if(Control.isControl()){
            controller.Move(horizontalMove, jump);
            jump = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
