using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private Text winText;
    private Text timer;
    private Text startText;

    private float startDelay;
    private float waitRestart;

    public float time;
    public static int rounds = 2;
    public static bool gameWon;
    public bool gameOver = false;

    public static Stack<string> playerPlacing;
    public static int[] playerPoints = new int[4];

    private Transform platform;
    private float shrinkRate = 0.1f;
    private int numPlayers;
    private int playerNum;
    private string winPlayer;

    //used to keep only one instance of this script
    public static UIManager master;

    void restart()
    {
        if (waitRestart > 0f)
        {
            waitRestart -= Time.deltaTime;
        }
        else {
            Debug.Log(rounds);
            if (rounds > 0)
            {
                rounds--;
                resetVariables();
                SceneManager.LoadScene("Balls");
            }
            else
            {
                //winning player score increments constantly, fix this
                //also add a way to keep track of the current rounds
                //little player icons in the corners of the screen to show score?
                //also, destroy the script when done with everything
                PlayerPrefs.SetInt("player1_score", PlayerPrefs.GetInt("player1_score") + playerPoints[0]);
                PlayerPrefs.SetInt("player2_score", PlayerPrefs.GetInt("player2_score") + playerPoints[1]);
                PlayerPrefs.SetInt("player3_score", PlayerPrefs.GetInt("player3_score") + playerPoints[2]);
                PlayerPrefs.SetInt("player4_score", PlayerPrefs.GetInt("player4_score") + playerPoints[3]);
                //load next scene for game
				Destroy(gameObject);
                SceneManager.LoadScene("UsingTilesStory");
                //Debug.Log(playerPoints[0] + " " + playerPoints[1] + " " + playerPoints[2] + " " + playerPoints[3]);
            }
        }
    }

    void resetVariables()
    {
        playerPlacing = new Stack<string>();
        platform = GameObject.Find("Platform").transform;
        gameWon = false;
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.gameObject.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
        startText = GameObject.Find("StartText").GetComponent<Text>();
        startDelay = 3f;
        waitRestart = 3f;
        time = 60f;
        gameWon = true;
    }

    void MakeOnlyOne()
    {
        if (master == null)
        {
            DontDestroyOnLoad(gameObject);
            master = this;
        }
        else {
            if (master != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        MakeOnlyOne();
        playerPlacing = new Stack<string>();
        platform = GameObject.Find("Platform").transform;
        gameWon = false;
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.gameObject.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
        startText = GameObject.Find("StartText").GetComponent<Text>();
        startDelay = 3f;
        waitRestart = 3f;
        time = 60f;
        gameWon = true;
        numPlayers = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>().num_players;
    }

    // Update is called once per frame
    void Update()
    {
        if (startDelay >= 0)
        {
            if(startDelay >= 2) startText.text = "Ready";
            else if (startDelay >= 1) startText.text = "Set";
            else if (startDelay >= .1) startText.text = "Go!";
            else
            {
                gameWon = false;
                startText.text = "";
            }
            startDelay -= Time.deltaTime;
        }
        else
        {
            //Debug.Log("Is find object getting the playerno?" + GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>().playerNo);
            //Debug.Log("Is find object getting the playerno?" + GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>().playerNo);

            if (playerPlacing.Count >= numPlayers-1)
            {
                gameWon = true;
                winText.gameObject.SetActive(true);
                //get the last player alive and puts them into the stack
                //Debug.Log("UImanager PlayerNo: " + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerNo);
                for(int i = 1; i <= 4; i++)
                {
                    string player = "Player" + i;
                    
                    if(GameObject.FindGameObjectWithTag(player) != null)
                    {
                        playerNum = GameObject.FindGameObjectWithTag(player).GetComponent<PlayerMovement>().playerNo;
                        winPlayer = "Player " + i;
                    }
                    else
                    {
                        string p = "ok";
                    }
                }
                    

                //add points to player
                playerPlacing.Push(winPlayer);
                playerPoints[playerNum - 1] += 5;

                winText.text = winPlayer + " wins!";
                restart();
            }
            else if (time <= 0)
            {
                platform.localScale -= new Vector3(shrinkRate * Time.deltaTime, shrinkRate * Time.deltaTime, 0);
                timer.text = "0";
            }
            else
            {
                platform = GameObject.Find("Platform").transform;
                time -= Time.deltaTime;
                timer.text = time.ToString("n0");
            }
        }
    }
}