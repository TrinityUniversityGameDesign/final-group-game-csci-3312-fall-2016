using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private Text winText;
    private Text timer;

    public float time = 60f;
    public int rounds = 3;
    public static bool gameWon = false;

    public static Stack<string> playerPlacing;
    public static int[] playerPoints = new int[4];

    private Transform platform;
    private float shrinkRate = 0.1f;

    // Use this for initialization
    void Start()
    {
        playerPlacing = new Stack<string>();
        platform = GameObject.Find("Platform").transform;
        gameWon = false;
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.gameObject.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
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
            playerPoints[playerNum] += playerPlacing.Count;

            winText.text = winPlayer + " wins!";
            float waitRestart = 3f;
            while(waitRestart > 0f)
            {
                waitRestart -= Time.deltaTime;
            }
            SceneManager.LoadScene("Balls");
        }
        else if (time <= 0)
        {
            platform.localScale -= new Vector3(shrinkRate*Time.deltaTime, shrinkRate*Time.deltaTime, 0);
            timer.text = "0";
        }
        else
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("n0");
        }
    }
}