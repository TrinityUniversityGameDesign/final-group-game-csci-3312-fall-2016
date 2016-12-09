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
    public GameObject blueJacket;
    public GameObject greenJacket;
    public GameObject redJacket;
    public GameObject yellowJacket;
    public GameObject terrainGenerator;

    bool startingNewRound = false;


    List<GameObject> playersInPlay = new List<GameObject>();
	List<GameObject> allPlayers = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		roundText = GameObject.Find ("RoundText").GetComponent<Text>();
		roundText.text = "Round 1";
		maxRoundNumber = 5;
		currentRoundNumber = 1;
		foreach(GameObject playerObj in GameObject.FindGameObjectsWithTag("Player")) {
			playersInPlay.Add(playerObj);
			allPlayers.Add (playerObj);
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (!startingNewRound)
        {
            if (playersInPlay.Count < 2)
            {
                playersInPlay[0].GetComponent<PlayerMovement_Jacket>().AddPoint();
                StartCoroutine(StartNewRound());
            }
            foreach (GameObject playerObj in allPlayers)
            {
                if (playerObj.GetComponent<PlayerMovement_Jacket>().IsDead())
                {
                    playersInPlay.Remove(playerObj);
                }
            }
        }
	}

	private IEnumerator StartNewRound(){
        roundText.text = "A New Round is About to Begin!";
        startingNewRound = true;
        yield return new WaitForSeconds(3);
        terrainGenerator.GetComponent<TerrainGenerator>().doEverything();
        currentRoundNumber++;
		roundText.text = "Round " + currentRoundNumber;
		playersInPlay = new List<GameObject> ();
		foreach(GameObject playerObj in GameObject.FindGameObjectsWithTag("Player")) {
			playerObj.GetComponent<PlayerMovement_Jacket> ().Respawn ();

            greenJacket.GetComponent<JacketScript>().SuckAllDaAirOut();
            redJacket.GetComponent<JacketScript>().SuckAllDaAirOut();
            blueJacket.GetComponent<JacketScript>().SuckAllDaAirOut();
            yellowJacket.GetComponent<JacketScript>().SuckAllDaAirOut();

            playersInPlay.Add(playerObj);
		}

		if (currentRoundNumber > maxRoundNumber) {
			//next levels
		}
        startingNewRound = false;
	}
}
