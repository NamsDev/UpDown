using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{

	Rigidbody2D rg;
	static bool a;

	// Use this for initialization
	void Start()
	{
		rg = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{

		if (a)
			rg.AddForce(Vector2.up, ForceMode2D.Force);
		Debug.Log(rg.velocity.magnitude);
		a = !a;
	}

}
