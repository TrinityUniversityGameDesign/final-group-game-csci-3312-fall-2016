using UnityEngine;
using System.Collections;

public class PPDefScript : MonoBehaviour {

	void Awake(){
        PlayerPrefs.SetInt("NumPlayers", 4);

		PlayerPrefs.SetInt ("player1_score", 1);
		PlayerPrefs.SetInt ("player2_score", 2);
		PlayerPrefs.SetInt ("player3_score", 3);
		PlayerPrefs.SetInt ("player4_score", 4);

		PlayerPrefs.SetString ("player1_name", "Beano");
		PlayerPrefs.SetString ("player2_name", "Cheddar");
		PlayerPrefs.SetString ("player3_name", "Nad");
		PlayerPrefs.SetString ("player4_name", "Bonus Jonas");

		PlayerPrefs.SetString ("player1_color", "#4286f4");
		PlayerPrefs.SetString ("player2_color", "#7af442");
		PlayerPrefs.SetString ("player3_color", "#af2845");
		PlayerPrefs.SetString ("player3_color", "#d8d50f");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
