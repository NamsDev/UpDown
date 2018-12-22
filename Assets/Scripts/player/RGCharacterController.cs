using UnityEditor;
using UnityEngine;

public class RGCharacterController : MonoBehaviour
{
	//used for movement
	public float maxSpeed = 3;
	public float maxDownSpeed = 0f;

	public float acceleration = 1;
	public float jumpForce = 1;

	public bool isReversed;
	private int isReversedInt;

	private bool isFacingRight = true;
	private Vector2 storedForce;
	private Vector2 currentVelocity;
	private Vector2 oldVelocity;

	//used for ground check
	public Transform groundCheck;
	public float radius;
	public LayerMask whatIsGround;

	private Animator animator;
	private new Rigidbody2D rigidbody;

	// Use this for initialization
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		isReversedInt = isReversed ? -1 : 1;

	}

	void FixedUpdate()
	{
		storedForce = Vector2.zero;


		if ((rigidbody.velocity.x < 0 && isFacingRight) || (rigidbody.velocity.x > 0 && !isFacingRight))
		{
			SwapSide();
		}

		animator.SetFloat("xSpeed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetFloat("ySpeed", rigidbody.velocity.y * isReversedInt);
	}

	public void Jump()
	{
		rigidbody.velocity += jumpForce * Vector2.up * isReversedInt;
	}

	public void Move(float input)
	{
		//compute the velocity to actually set
		if (input == 0)
			return;

		var addedSpeed = input * acceleration * Time.fixedDeltaTime;
		if ((rigidbody.velocity.x  + addedSpeed) / input < maxSpeed)
		{
			rigidbody.velocity += addedSpeed * Vector2.right;
		}
		else
		{
			rigidbody.velocity = new Vector2(input * maxSpeed, rigidbody.velocity.y);
		}
	}

	private void SwapSide()
	{
		transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
		isFacingRight = !isFacingRight;
	}

	void OnDrawGizmosSelected()
	{
		Handles.color = Color.green;
		Handles.DrawWireDisc(groundCheck.position, groundCheck.transform.forward, radius);
	}
}
