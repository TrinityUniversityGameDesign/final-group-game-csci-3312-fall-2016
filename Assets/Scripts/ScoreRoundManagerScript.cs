using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Text;

public class ScoreRoundManagerScript : MonoBehaviour {
	private Text roundText;
	private int maxRoundNumber;
	private int maxPlayers = 4;
	private int currentRoundNumber;
	private int currentPlayers = 1;
	List<GameObject> playersInPlay = new List<GameObject>();
	// Use this for initialization
	void Start () {
		roundText = GameObject.Find ("RoundText").GetComponent<Text>();
		roundText.text = "Round 1";
		maxRoundNumber = 5;
		currentRoundNumber = 1;
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
		foreach(GameObject playerObj in playersInPlay) {
			if (playerObj.GetComponent<PlayerMovement_Jacket> ().IsDead ()) {
				playersInPlay.Remove (playerObj);
			}
		}
	}

	private void StartNewRound(){
		currentRoundNumber++;
		roundText.text = "Round " + currentRoundNumber;
		playersInPlay = new List<GameObject> ();
		foreach(GameObject playerObj in GameObject.FindGameObjectsWithTag("Player")) {
			playerObj.GetComponent<PlayerMovement_Jacket> ().Respawn ();
			playersInPlay.Add(playerObj);
		}

		if (currentRoundNumber > maxRoundNumber) {
			//next levels
		}
	}
}
