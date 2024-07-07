using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;						
	[SerializeField] private LayerMask m_WhatIsGround;						
	[SerializeField] private Transform m_GroundCheck;							

	private bool m_Grounded;         
	private Rigidbody2D m_Rigidbody2D;
	private Collision2D colliders;
	private bool m_FacingRight = true;  	
	private Vector3 m_Velocity = Vector3.zero;
	private int m_JumpForce = 200;

	[Header("Events")]

	[Space]
	public UnityEvent OnLandEvent;
	
	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		if(colliders != null){
			if (colliders.gameObject != gameObject)
			{
				m_Grounded = true;
				colliders = null;
				OnLandEvent.Invoke();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other){
		colliders = other;
	}

	public void Move(float move, bool jump)
	{
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}
		if (m_Grounded && jump)
		{
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

	public bool groundCheck(){
		return m_Grounded;
	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
