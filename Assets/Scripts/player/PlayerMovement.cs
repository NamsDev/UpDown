using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D), typeof(Animator), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float gravity = -15f;

	[SerializeField]
	private float runSpeed = 8f;

	[SerializeField]
	public float groundDamping = 15f; // how fast do we change direction? higher means faster
	[SerializeField]
	public float inAirDamping = 5f;

	[SerializeField]
	public float jumpHeight = 3f;

	//[SerializeField]
	public bool isReversed;
	private int isReversedInt { get { return isReversed ? -1 : 1; } }

	//internal state
	private Vector2 _velocity;

	//other components
	private Animator _animator;
	private Rigidbody2D _rigidbody;
	private CharacterController2D _controller;

	
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();
	}

	void Start()
	{
		_controller.isReversed = isReversed;
	}


	// Update is called once per frame
	void FixedUpdate () {

		_velocity.y += gravity * Time.fixedDeltaTime * isReversedInt;

		
		_controller.move(_velocity * Time.fixedDeltaTime);

		_velocity = _controller.velocity;

		_animator.SetFloat("xSpeed", _velocity.x);
		_animator.SetFloat("ySpeed", _velocity.y * isReversedInt);
	}

	public void Reset()
	{
		_controller.Reset();
	}

	public void HandleHorizontalInput(float input)
	{
		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp(_velocity.x, input * runSpeed, Time.deltaTime * smoothedMovementFactor);
	}

	public void Jump()
	{
		_velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity) * isReversedInt;
	}

	public void Duck()
	{
		if (_controller.isGrounded)
		{
			_velocity.y *= 3f;
			_controller.ignoreOneWayPlatformsThisFrame = true;
		}
	}

	//public void addvelocity(Vector2 _velocity)
	//{
	//	Velocity += _velocity;
	//}
}
