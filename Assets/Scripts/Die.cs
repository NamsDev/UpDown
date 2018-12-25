using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Lethal"))
		{
			GlobalEventSystem.OnPlayerDies.Invoke();
		}
	}
}
