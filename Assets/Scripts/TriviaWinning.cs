using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TriviaWinning : MonoBehaviour
{
    public Text TotalScore;
    public Text Fastest;
    public Text Slowest;
    public Text p4Score;
    // Use this for initialization
    int Player1Score;
    int Player2Score;
    int Player3Score;
    int Player4Score;


    int Player1Fastest;
    int Player2Fastest;
    int Player3Fastest;
    int Player4Fastest;

    int Player1Slowest;
    int Player2Slowest;
    int Player3Slowest;
    int Player4Slowest;
    int Score;
    int High;
    int Low;
    string whichPlayer;

    void Start()
    {
        Player1Score = PlayerPrefs.GetInt("Trivia Player 1");
        Player2Score = PlayerPrefs.GetInt("Trivia Player 2");
        Player3Score = PlayerPrefs.GetInt("Trivia Player 3");
        Player4Score = PlayerPrefs.GetInt("Trivia Player 4");

        Player1Fastest = PlayerPrefs.GetInt("Highest Trivia Player 1");
        Player2Fastest = PlayerPrefs.GetInt("Highest Trivia Player 2");
        Player3Fastest = PlayerPrefs.GetInt("Highest Trivia Player 3");
        Player4Fastest = PlayerPrefs.GetInt("Highest Trivia Player 4");


        Player1Slowest = PlayerPrefs.GetInt("Lowest Trivia Player 1");
        Player2Slowest = PlayerPrefs.GetInt("Lowest Trivia Player 2");
        Player3Slowest = PlayerPrefs.GetInt("Lowest Trivia Player 3");
        Player4Slowest = PlayerPrefs.GetInt("Lowest Trivia Player 4");



        TotalScore.text = "Highest Score \n" + getHighest(Player1Score, Player2Score, Player3Score, Player4Score,5).ToString() + whichPlayer;
        Fastest.text = "Fastest Correct Answer \n" + getHighest(Player1Fastest, Player2Fastest, Player3Fastest, Player4Fastest,3).ToString() + whichPlayer;
        Slowest.text = "Slowest Correct Answer \n"  + getLowest(Player1Slowest, Player2Slowest, Player3Slowest, Player4Slowest).ToString() + whichPlayer;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Start_P1") > 0)
        {
            SceneManager.LoadScene("scene1");
        }
    }
    int getHighest(int a, int b, int c, int d, int e)
    {
        if (a > b && a > c && a > d && a > 0)
        {
            whichPlayer = PlayerPrefs.GetString("Player1_Name");
            int temp = PlayerPrefs.GetInt("Player1_Score");
            PlayerPrefs.SetInt("Player1_Score", temp + e);
            return a;
        }
        else if (b > a && b > c && b > d && b > 0)
        {
            whichPlayer = PlayerPrefs.GetString("Player2_Name");
            int temp = PlayerPrefs.GetInt("Player2_Score");
            PlayerPrefs.SetInt("Player2_Score", temp + e);
            return b;

        }
        else if (c > a && c > b && c > d && c > 0)
        {
            whichPlayer = PlayerPrefs.GetString("Player3_Name");
            int temp = PlayerPrefs.GetInt("Player3_Score");
            PlayerPrefs.SetInt("Player3_Score", temp + e);
            return c;

        }
        else
        {
            whichPlayer = PlayerPrefs.GetString("Player4_Name");
            int temp = PlayerPrefs.GetInt("Player4_Score");
            PlayerPrefs.SetInt("Player4_Score", temp + e);
            return d;
        }
    }
    int getLowest(int a, int b, int c, int d)
    {
        if (a == 0)
            a = 1001;
        if (b == 0)
            b = 1001;
        if (c == 0)
            c = 1001;
        if (d == 0)
            d = 1001;
        if (a < b && a < c && a < d)
        {
            whichPlayer = PlayerPrefs.GetString("Player1_Name");
            int temp = PlayerPrefs.GetInt("Player1_Score");
            PlayerPrefs.SetInt("Player1_Score", temp + 1);
            return a;
        }
        else if (b < a && b < c && b < d)
        {
            whichPlayer = PlayerPrefs.GetString("Player2_Name");
            int temp = PlayerPrefs.GetInt("Player2_Score");
            PlayerPrefs.SetInt("Player2_Score", temp + 1);
            return b;

        }
        else if (c < a && c < b && c < d)
        {
            whichPlayer = PlayerPrefs.GetString("Player3_Name");
            int temp = PlayerPrefs.GetInt("Player3_Score");
            PlayerPrefs.SetInt("Player3_Score", temp + 1);
            return c;

        }
        else
        {
            whichPlayer = PlayerPrefs.GetString("Player4_Name");
            int temp = PlayerPrefs.GetInt("Player4_Score");
            PlayerPrefs.SetInt("Player4_Score", temp + 1);
            return d;
        }
    }
}
