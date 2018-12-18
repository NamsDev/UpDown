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

    private new Rigidbody2D rigidbody;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //animator.SetFloat("moveSpeed", Mathf.Abs(rigidbody.velocity.x));
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
