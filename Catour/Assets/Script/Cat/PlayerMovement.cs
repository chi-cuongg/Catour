using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 1f;

    float horizontalMove = 0f;
    bool jump = false;

    private float idleTime = 0f;
    private bool isIdle = false;
    private const float idleThreshold = 5f;
    private bool Control = true;
    //private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        controller.OnLandEvent.AddListener(OnLanding);
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && controller.Grounded)
        {
            jump = true;
            Debug.Log("Jump button pressed");
            animator.SetBool("IsJumping", true);
            //isGrounded = false;
            //Debug.Log("Set IsJumping to true, isGrounded: " + isGrounded);

        }



        if (Mathf.Abs(horizontalMove) > 0 || jump )
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

    public void OnLanding()
    {
        Debug.Log("Landed");
        //isGrounded = true;
        animator.SetBool("IsJumping", false);
        //Debug.Log("Set IsJumping to false, isGrounded: " + isGrounded);
    }


    public void disableControl()
    {
        Control = false;
    }

    public bool isControl()
    {
        return Control;
    }

    void FixedUpdate()
    {
        if (Control)
        {
            Debug.Log("Jumping in FixedUpdate");
            controller.Move(horizontalMove, false, jump);
            jump = false;
        }
        //else
        //{
        //    //Debug.Log("FixedUpdate: Control is false");
        //    controller.Move(horizontalMove, false, false);
        //}

    }

}