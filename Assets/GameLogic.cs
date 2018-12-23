using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
	[System.Serializable]
	public class IntEvent : UnityEvent<int>
	{}

	public IntEvent CheckPointEvent;

	// Use this for initialization
	void Start()
	{
		GlobalEventSystem.OnPlayerDies.AddListener(OnPlayerDiesEvent);
	}

	public void OnPlayerDiesEvent()
	{
		CheckPointEvent.Invoke(-1);
	}

	// Update is called once per frame
	void Update()
	{
		HandleCheatInput();
	}


	void HandleCheatInput()
	{

		//respawn at wantedcheckpoint
		for (int i = 0; i < 5; i++)
		{
			if (Input.GetKeyDown(i.ToString()))
			{
				CheckPointEvent.Invoke(i);
			}

		}
	}



}
