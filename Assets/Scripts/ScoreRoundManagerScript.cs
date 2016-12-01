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
    public GameObject logo;

    bool startingNewRound = false;


    List<GameObject> playersInPlay = new List<GameObject>();
	List<GameObject> allPlayers = new List<GameObject> ();
	// Use this for initialization
	void Start () {
        //logo.GetComponent<Transform>().localPosition = new Vector3(0, 0, 101);
        logo.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
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
        Debug.Log(logo.transform.localScale);
        while (logo.transform.localScale.x < 2f)
        {
            logo.transform.localScale += new Vector3(0.02f, 0.02f, 0.0f);
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log(logo.transform.localScale);
        logo.transform.localScale = new Vector3(0, 0, 0);
        //while (logo.GetComponent<Transform>().localPosition.z > -9) logo.GetComponent<Transform>().localPosition = new Vector3(logo.GetComponent<Transform>().localPosition.x, logo.GetComponent<Transform>().localPosition.y, logo.GetComponent<Transform>().localPosition.z - 1);
        //logo.GetComponent<Transform>().localPosition = new Vector3(0, 0, 101);
        yield return new WaitForSeconds(3);
        terrainGenerator.GetComponent<TerrainGenerator>().doEverything();
        //while(logo.GetComponent<Transform>().localPosition.z >-12) logo.GetComponent<Transform>().localPosition = new Vector3(logo.GetComponent<Transform>().localPosition.x, logo.GetComponent<Transform>().localPosition.y, logo.GetComponent<Transform>().localPosition.z-1);
        //logo.GetComponent<Transform>().localPosition = new Vector3(0, 0, 101);
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
