using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	Rigidbody rg;

	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rg.AddForce(Vector3.up, ForceMode.Force);
		Debug.Log(rg.velocity.magnitude);
	}
}
