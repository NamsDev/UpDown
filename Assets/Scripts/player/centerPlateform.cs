using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerPlateform : MonoBehaviour {

	public Transform yin;
	public Transform yan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (yin.position + yan.position) / 2;
	}
}
