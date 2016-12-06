using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TriviaWinning : MonoBehaviour
{
    public Text p1Score;
    public Text p2Score;
    public Text p3Score;
    public Text p4Score;
    // Use this for initialization
    void Start()
    {
        p1Score.text = "Player 1 Score \n" + PlayerPrefs.GetInt("Trivia Player 1").ToString();
        p2Score.text = "Player 2 Score \n" + PlayerPrefs.GetInt("Trivia Player 2").ToString();
        p3Score.text = "Player 3 Score \n" + PlayerPrefs.GetInt("Trivia Player 3").ToString();
        p4Score.text = "Player 4 Score \n" + PlayerPrefs.GetInt("Trivia Player 4").ToString();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Start_P1") > 0)
        {
            SceneManager.LoadScene("scene1");
        }
    }
}
