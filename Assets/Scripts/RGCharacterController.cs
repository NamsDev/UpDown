using UnityEditor;
using UnityEngine;

public class RGCharacterController : MonoBehaviour
{
	public float maxSpeed = 3;
	public float acceleration = 1;
	public float jumpForce = 1;
	public bool isReversed;

	public Transform groundCheck;
	public float radius;
	public LayerMask whatIsGround;

	private Animator animator;
	private Rigidbody2D rigidbody;
	private bool isFacingRight = true;

	// Use this for initialization
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}


	void FixedUpdate()
	{
		Debug.Log(rigidbody.velocity + "   FU");
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(rigidbody.velocity + "   U");

		if ((rigidbody.velocity.x < 0 && isFacingRight) || (rigidbody.velocity.x > 0 && !isFacingRight))
		{
			SwapSide();
		}
		animator.SetFloat("xSpeed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetFloat("ySpeed", rigidbody.velocity.y * (isReversed ? -1 : 1));
	}

	public void Jump()
	{
		rigidbody.AddForce(jumpForce * Vector2.up * (isReversed ? -1 : 1), ForceMode2D.Impulse);
	}

	public void Move(float input) //ratio is [-1:1]
	{
		//if (Mathf.Abs(rigidbody.velocity.x) < maxSpeed * Mathf.Abs(input))
		{
			rigidbody.AddForce(input * acceleration * Vector2.right);
		}

		Debug.Log(rigidbody.velocity + "   SU");

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
