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
	private int isReversedInt { get { return isReversed ? -1 : 1; } }

	private bool isFacingRight = true;
	private Vector2 addedVelocity;

	//used for ground check
	public Transform groundCheck;
	public float radius;
	public LayerMask whatIsGround;

	private Animator animator;
	private new Rigidbody2D rigidbody;

	// Use this for initialization
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}

	public void Reset()
	{
		rigidbody.velocity = Vector2.zero;
		animator.Rebind();
	}

	void FixedUpdate()
	{
		rigidbody.velocity += addedVelocity;
		addedVelocity = Vector2.zero;
	}

	void Update()
	{
		if ((rigidbody.velocity.x < 0 && isFacingRight) || (rigidbody.velocity.x > 0 && !isFacingRight))
		{
			SwapSide();
		}

		animator.SetFloat("xSpeed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetFloat("ySpeed", rigidbody.velocity.y * isReversedInt);
	}

	public void Jump()
	{
		addedVelocity += jumpForce * Vector2.up * isReversedInt;
	}

	public void Move(float input)
	{
		//compute the velocity to actually set
		if (input == 0)
			return;

		var addedSpeed = input * acceleration * Time.deltaTime;
		if ((rigidbody.velocity.x + addedVelocity.x + addedSpeed) / input < maxSpeed)
		{
			addedVelocity += addedSpeed * Vector2.right;
		}
		else
		{
			//addedVelocity = new Vector2(input * maxSpeed, rigidbody.velocity.y);
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
