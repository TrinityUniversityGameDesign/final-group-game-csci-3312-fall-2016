using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private Text winText;
    private Text timer;

    public float time = 60f;
    public static bool gameWon = false;

    public static Stack<string> playerPlacing = new Stack<string>();

    // Use this for initialization
    void Start()
    {
        playerPlacing = new Stack<string>();
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
            string winPlayer = GameObject.FindGameObjectWithTag("Player").name;
            playerPlacing.Push(winPlayer);
            winText.text = winPlayer + " wins!";
        }
        else if (time <= 0)
        {
            gameWon = true;
            winText.gameObject.SetActive(true);
            timer.text = "0";
            winText.text = "Game Over";
        }
        else
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("n0");
        }
    }
}