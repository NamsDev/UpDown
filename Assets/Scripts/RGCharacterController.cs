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

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
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
    }
}
