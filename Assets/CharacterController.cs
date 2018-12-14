using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public bool isReversed;
    public float maxSpeed = 1;

    private Rigidbody2D rigidbody;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        float input = Input.GetAxis("Horizontal");
        input *= isReversed ? -1 : 1;

        Debug.Log(input);

        rigidbody.velocity = new Vector2(input * maxSpeed, rigidbody.velocity.y);
	}
}
