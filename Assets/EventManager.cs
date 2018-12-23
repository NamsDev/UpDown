using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	[System.Serializable]
	public class IntEvent : UnityEvent<int>
	{
	}

	public IntEvent CheckPointEvent;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		HandleDebugInput();
	}


	void HandleDebugInput()
	{
		for (int i = 1; i < 5; i++)
		{
			if (Input.GetKeyDown(i.ToString()))
			{
				CheckPointEvent.Invoke(i);
			}

		}
	}

}
