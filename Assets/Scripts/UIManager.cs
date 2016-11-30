using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private Text winText;
    private Text timer;
    private Text startText;

    public float time = 60f;
    public float startDelay = 3f;
    public static bool gameWon = false;

    public static Stack<string> playerPlacing = new Stack<string>();

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
        startText = GameObject.Find("StartText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            if(startDelay <= 3 && startDelay > 2)
            {
                startText.text = "Ready";
            }
            else if (startDelay <= 2 && startDelay > 1)
            {
                startText.text = "Set";
            }
            else if (startDelay <= 1)
            {
                startText.text = "Go!";
            }
        }
        else
        {
            startText.gameObject.SetActive(false);
            if (playerPlacing.Count >= 3)
            {
                gameWon = true;
                winText.gameObject.SetActive(true);
                //get the last player alive and puts them into the stack
                string winPlayer = GameObject.FindGameObjectWithTag("Player").name;
                playerPlacing.Push(winPlayer);
                winText.text = winPlayer + " wins!";
            }
            else if (time <= 0)
            {
                //shrinks platform into nothingness
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