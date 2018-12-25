using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAtCheckPoint : MonoBehaviour
{
	private int currentCheckpoint = 0;
	Transform playerUp;
	Transform playerDown;

	void Awake()
	{
		var players = GameObject.FindGameObjectsWithTag("Player");

		foreach (var player in players)
		{
			if (player.GetComponent<PlayerMovement>().isReversed)
				playerDown = player.transform;
			else
				playerUp = player.transform;
		}
	}


	// Use this for initialization
	void Start()
	{
		SpawnAtCP(0);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SpawnAtCP(int cp)
	{
		if (cp == -1)
			cp = currentCheckpoint;

		//reset players velocity
		playerUp.GetComponent<PlayerMovement>().Reset();
		playerDown.GetComponent<PlayerMovement>().Reset();

		//set position
		var CP = transform.Find("Checkpoint (" + cp + ")");
		if (CP == null)
		{
			Debug.Log("There is no CP" + cp);
			return;
		}
		playerUp.transform.position = CP.Find("CP Up").transform.position;
		playerDown.transform.position = CP.Find("CP Down").transform.position;

	}
}
