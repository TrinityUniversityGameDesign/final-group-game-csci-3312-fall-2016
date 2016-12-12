using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EndingScene : MonoBehaviour {
    public GameObject First;

    // Use this for initialization
    public GameObject statue;
    public GameObject scores;
    int numPlayers;
    
    void Start () {
    
       /* PlayerPrefs.SetInt("NumPlayers", 4);
        PlayerPrefs.SetString("player1_name", "Miguel");
        PlayerPrefs.SetInt("player1_score", 4);
        PlayerPrefs.SetString("player2_name", "Po");
        PlayerPrefs.SetInt("player2_score", 3);
        PlayerPrefs.SetString("player3_name", "Subrat");
        PlayerPrefs.SetInt("player3_score", 2);
        PlayerPrefs.SetString("player4_name", "Mary");
        PlayerPrefs.SetInt("player4_score", 1);*/
        numPlayers = PlayerPrefs.GetInt("NumPlayers");
       // Debug.Log(numPlayers);
        SetScores();

    }
	void SetScores()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        for(int i=1;i<=numPlayers; i++)
        {
            scores.Add(PlayerPrefs.GetString("player" + i + "_name"), PlayerPrefs.GetInt("player" + i + "_score"));
        }
        var items = from pair in scores
                    orderby pair.Value descending
                    select pair;
        int pos = 1;
        Text scoreDisplay = First.GetComponent<Text>();
        foreach (KeyValuePair<string, int> pair in items)
        {
            scoreDisplay.text = scoreDisplay.text + pos + ". " + pair.Key + "\n";
            pos++;
        }

    }

	// Update is called once per frame
	void Update () {
	    if(statue.transform.position.y < 300 && statue.transform.localScale.x < 1900 && statue.transform.localScale.y < 1900)
        {
            statue.transform.position = new Vector3(statue.transform.position.x, statue.transform.position.y + Time.deltaTime * 300*(5f/18f), statue.transform.position.z);
            statue.transform.localScale = new Vector3(statue.transform.localScale.x + Time.deltaTime * 500, statue.transform.localScale.y + Time.deltaTime * 500, statue.transform.localScale.z);
            scores.transform.localScale = new Vector3(scores.transform.localScale.x + Time.deltaTime * 0.9f * (5f / 18f), scores.transform.localScale.y + Time.deltaTime * 0.9f * (5f / 18f), scores.transform.localScale.z);
        }
	}
}
