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
        Debug.Log(currentVelocity);
        Debug.Log(isReversedInt);
        Debug.Log(currentVelocity);

        //if (currentVelocity.y * isReversedInt > -maxDownSpeed)
        //    storedForce += Globals.gravity * Time.fixedDeltaTime * (isReversed ? Vector2.down : Vector2.up);


        currentVelocity = currentVelocity + storedForce * Time.fixedDeltaTime;
        ApplyMovement(ref currentVelocity);

        storedForce = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentVelocity.x < 0 && isFacingRight) || (currentVelocity.x > 0 && !isFacingRight))
        {
            SwapSide();
        }
        animator.SetFloat("xSpeed", Mathf.Abs(rigidbody.velocity.x));
        animator.SetFloat("ySpeed", rigidbody.velocity.y * isReversedInt);
    }

    public void Jump()
    {
        storedForce += jumpForce * Vector2.up * (isReversed ? -1 : 1);
    }

    public void Move(float input) //ratio is [-1:1]
    {
        if (Mathf.Abs(currentVelocity.x) < maxSpeed * Mathf.Abs(input))
        {
            storedForce += input * acceleration * Vector2.right * Time.deltaTime;
        }
    }

    private void SwapSide()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        isFacingRight = !isFacingRight;
    }

    private void ApplyMovement(ref Vector2 velocity)
    {
        rigidbody.MovePosition(rigidbody.position + velocity);

    }


    void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(groundCheck.position, groundCheck.transform.forward, radius);
    }
}
