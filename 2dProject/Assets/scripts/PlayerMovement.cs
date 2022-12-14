using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Start is called before the first frame update

	private Rigidbody2D rb;

	public float movementSpeed = 5;

	public float jumpForce = 15;

	private float xDirection;

	public Transform[] groundCheck;

	public LayerMask groundMask;

	public float checkgroundDistance = 1f;

	public FixedJoystick myJoystick;

	public Animator playerSriteAnimator;

	public Transform playerSprite;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void Update()
	{
		xDirection = myJoystick.Horizontal;

		playerSriteAnimator.SetFloat("Speed", Mathf.Abs(xDirection));

		if (myJoystick.Vertical > 0.7f && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}

		if (xDirection > 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if (xDirection < 0)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}

		if (rb.velocity.y != 0)
		{
			playerSriteAnimator.SetBool("IsJumping", true);
		}
		else
		{
			playerSriteAnimator.SetBool("IsJumping", false);
		}
	}

	public void Jump()
	{
		if (IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}

	private bool IsGrounded()
	{
		for (int i = 0; i < groundCheck.Length; i++)
		{
			if (Physics2D.Raycast(groundCheck[i].position, -groundCheck[i].up, checkgroundDistance, groundMask))
			{
				return true;
			}
		}

		return false;
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(xDirection * movementSpeed, rb.velocity.y);
	}
}