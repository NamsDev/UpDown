using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 3;
    public float acceleration = 1;
    public float jumpForce = 1;
	public bool isReversed;

	private Rigidbody2D rigidbody;
	private Vector2 velocity;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		////handle gravity
		//rigidbody.velocity += new Vector2(0, Globals.gravity * Time.deltaTime);

		//handle input
		float input = Input.GetAxis("Horizontal");
		if (Mathf.Abs(rigidbody.velocity.x) < maxSpeed * Mathf.Abs(input))
		{
			rigidbody.AddForce(input * acceleration * Vector2.right);
		}
		
		//handle jump
		if (Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(jumpForce * Vector2.up * (isReversed ? -1 : 1), ForceMode2D.Impulse);
		}

	}
}
