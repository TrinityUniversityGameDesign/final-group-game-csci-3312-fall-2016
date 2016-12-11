using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class ScoreRoundManagerScript : MonoBehaviour {
	private Text roundText;
	private int maxPlayers = 4;
	private int currentRoundNumber;
	private int currentPlayers = 1;
    private bool startingNewRound = false;
    private List<GameObject> playersInPlay = new List<GameObject>();
    private List<GameObject> allPlayers = new List<GameObject>();

    public int maxRoundNumber;
    public string nextScene;
    public GameObject blueJacket;
    public GameObject greenJacket;
    public GameObject redJacket;
    public GameObject yellowJacket;
    public GameObject terrainGenerator;
    public GameObject logo;
    
	// Use this for initialization
	void Start () {
        //logo.GetComponent<Transform>().localPosition = new Vector3(0, 0, 101);
        logo.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
		roundText = GameObject.Find ("RoundText").GetComponent<Text>();
		roundText.text = "Round 1";
		currentRoundNumber = 1;
		foreach(GameObject playerObj in GameObject.FindGameObjectsWithTag("Player")) {
			playersInPlay.Add(playerObj);
			allPlayers.Add(playerObj);
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

    private IEnumerator StartNewRound() {
        startingNewRound = true;
        float maxLogoSize = 38f;
        while (logo.transform.localScale.x < maxLogoSize)
        {
            float growFactor = 1 + 200 * (logo.transform.localScale.x / maxLogoSize);
            logo.transform.localScale += new Vector3(0.01f * growFactor, 0.01f * growFactor, 0.0f);
            yield return new WaitForSeconds(0.001f);
        }
        logo.transform.localScale = new Vector3(0, 0, 0);
        if (currentRoundNumber >= maxRoundNumber)
        {
            playersInPlay[0].GetComponent<PlayerMovement_Jacket>().SendWinner();
            LoadNextScene();
        }
        else
        {
            currentRoundNumber++;
            roundText.text = "A New Round is About to Begin!";
            terrainGenerator.GetComponent<TerrainGenerator>().doEverything();
            roundText.text = "Round " + currentRoundNumber;
            playersInPlay = new List<GameObject>();
            foreach (GameObject playerObj in GameObject.FindGameObjectsWithTag("Player"))
            {
                playerObj.GetComponent<PlayerMovement_Jacket>().Respawn();

                greenJacket.GetComponent<JacketScript>().SuckAllDaAirOut();
                redJacket.GetComponent<JacketScript>().SuckAllDaAirOut();
                blueJacket.GetComponent<JacketScript>().SuckAllDaAirOut();
                yellowJacket.GetComponent<JacketScript>().SuckAllDaAirOut();

                playersInPlay.Add(playerObj);
            }
            yield return new WaitForSeconds(2);
        }
        startingNewRound = false;
	}

    void LoadNextScene() { SceneManager.LoadScene(nextScene); }
}
