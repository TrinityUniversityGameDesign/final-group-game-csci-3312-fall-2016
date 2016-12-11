using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPrefsManager : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;

    private int numPlayers;
    private List<string> playerNames;
    private List<int> playerScores;
    private List<string> playerColors;
    private List<GameObject> playerObjects;

    void Awake()
    {
        playerObjects = new List<GameObject> { playerOne, playerTwo, playerThree, playerFour };
    }
    
	// Use this for initialization
	void Start () {
        for(int i=0; i<numPlayers; i++) {
            playerObjects[i].SetActive(true);
        }
	    for(int i=1; i<(numPlayers+1); i++) {
            playerNames.Add(PlayerPrefs.GetString("player" + i + "_score"));
            playerScores.Add(PlayerPrefs.GetInt("player" + i + "_score"));
            playerColors.Add(PlayerPrefs.GetString("player" + i + "_color"));
        }
        for(int i=0; i<numPlayers; i++) {

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
