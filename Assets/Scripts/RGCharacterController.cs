using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGCharacterController : MonoBehaviour
{
	public float maxSpeed = 3;
	public float acceleration = 1;
	public float jumpForce = 1;
	public bool isReversed;

	private Rigidbody2D rigidbody;
	private Animator animator;
	private bool isFacingRight = true;

	// Use this for initialization
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if ( (rigidbody.velocity.x < 0 && isFacingRight) || (rigidbody.velocity.x > 0 && !isFacingRight))
		{
			SwapSide();
		}
		//animator.SetFloat("moveSpeed", Mathf.Abs(rigidbody.velocity.x)); TODO ask
	}

	public void Jump()
	{
		rigidbody.AddForce(jumpForce * Vector2.up * (isReversed ? -1 : 1), ForceMode2D.Impulse);
	}

	public void Move(float input) //ratio is [-1:1]
	{
		if (Mathf.Abs(rigidbody.velocity.x) < maxSpeed * Mathf.Abs(input))
		{
			rigidbody.AddForce(input * acceleration * Vector2.right);
		}
		animator.SetFloat("moveSpeed", Mathf.Abs(input));


	}

	private void SwapSide()
	{
		transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
		isFacingRight = !isFacingRight;
	}

}
