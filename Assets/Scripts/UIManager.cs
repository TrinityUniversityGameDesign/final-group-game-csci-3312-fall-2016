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
    public static int rounds = 3;
    public static bool gameWon;

    public static Stack<string> playerPlacing;
    public static int[] playerPoints = new int[4];

    private Transform platform;
    private float shrinkRate = 0.1f;

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
                Destroy(this);
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
            if (playerPlacing.Count >= 3)
            {
                gameWon = true;
                winText.gameObject.SetActive(true);
                //get the last player alive and puts them into the stack
                int playerNum = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerNo;
                string winPlayer = "Player " + playerNum;

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
                time -= Time.deltaTime;
                timer.text = time.ToString("n0");
            }
        }
    }
}