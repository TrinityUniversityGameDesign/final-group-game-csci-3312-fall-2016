using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreRoundManagerScript : MonoBehaviour {
	private int maxPlayers = 4;
	private int currentPlayers = 1;
	List<GameObject> playersInPlay = new List<GameObject>();
	// Use this for initialization
	void Start () {
		foreach(GameObject playerObj in GameObject.FindGameObjectsWithTag("Player")) {
			playersInPlay.Add(playerObj);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playersInPlay.Count < 2) {
			playersInPlay [0].GetComponent<PlayerMovement_Jacket> ().AddPoint ();
			StartNewRound ();
		}
	}

	private void StartNewRound(){
		playersInPlay = new List<GameObject> ();
		foreach(GameObject playerObj in GameObject.FindGameObjectsWithTag("Player")) {
			playerObj.GetComponent<PlayerMovement_Jacket> ().Respawn ();
			playersInPlay.Add(playerObj);
		}
	}
}
