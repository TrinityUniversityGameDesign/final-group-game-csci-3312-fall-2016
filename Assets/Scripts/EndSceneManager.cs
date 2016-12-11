using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour {

	public GameObject alldat;

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;
    public GameObject nameOne;
    public GameObject nameTwo;
    public GameObject nameThree;
    public GameObject nameFour;
    public GameObject scoreOne;
    public GameObject scoreTwo;
    public GameObject scoreThree;
    public GameObject scoreFour;

    private GameObject playerPrefsManager;
    private int numPlayers;
    private List<GameObject> playerObjects;
    private List<GameObject> currentPlayers;
    private List<GameObject> nameTexts;
    private List<GameObject> currentNameTexts;
    private List<GameObject> scoreTexts;
    private List<GameObject> currentScoreTexts;

    void Awake()
    {
        playerObjects = new List<GameObject>();
        currentPlayers = new List<GameObject>();
        nameTexts = new List<GameObject>();
        currentNameTexts = new List<GameObject>();
        scoreTexts = new List<GameObject>();
        currentScoreTexts = new List<GameObject>();

        playerPrefsManager = GameObject.Find("PlayerPrefsManager") as GameObject;
        numPlayers = playerPrefsManager.GetComponent<PlayerPrefsManager>().GetNumPlayers();
        playerObjects = new List<GameObject> { playerOne, playerTwo, playerThree, playerFour };
        nameTexts = new List<GameObject> { nameOne, nameTwo, nameThree, nameFour };
        scoreTexts = new List<GameObject> { scoreOne, scoreTwo, scoreThree, scoreFour };
        for (int i = 0; i < numPlayers; i++)
        {
            playerObjects[i].SetActive(false);
            nameTexts[i].SetActive(false);
            scoreTexts[i].SetActive(false);
        }
        ActivateCurrentPlayers();
        SetPlayerInfo();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("A_P1")) {
            Destroy(GameObject.Find("SoundManager"));
            Destroy(GameObject.Find("PlayerPrefsManagers"));
            Destroy(GameObject.Find("ScoreManager"));
			Destroy (alldat);
            SceneManager.LoadScene("UsingTilesStory");
        }
	}

    void ActivateCurrentPlayers()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            playerObjects[i].SetActive(true);
            nameTexts[i].SetActive(true);
            scoreTexts[i].SetActive(true);
            currentPlayers.Add(playerObjects[i]);
            currentNameTexts.Add(nameTexts[i]);
            currentScoreTexts.Add(scoreTexts[i]);
        }
    }

    void SetPlayerInfo()
    {
        for(int i=0; i<numPlayers; i++)
        {
            currentPlayers[i].transform.FindChild("WinnerClothes").GetComponent<SpriteRenderer>().color = playerPrefsManager.GetComponent<PlayerPrefsManager>().GetPlayerColor(i);
            currentPlayers[i].name = playerPrefsManager.GetComponent<PlayerPrefsManager>().GetPlayerName(i);
            currentNameTexts[i].GetComponent<Text>().text = currentPlayers[i].name;
            currentScoreTexts[i].GetComponent<Text>().text = (playerPrefsManager.GetComponent<PlayerPrefsManager>().GetPlayerScore(i)).ToString();
        }
    }
}
