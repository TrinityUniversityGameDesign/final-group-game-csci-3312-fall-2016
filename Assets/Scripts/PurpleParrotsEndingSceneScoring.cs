using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PurpleParrotsEndingSceneScoring : MonoBehaviour {

	public int player1_rank = 1;
	public int player2_rank = 2;
	public int player3_rank = 3;
	public int player4_rank = 4;

	public float column1_adj; // the height player# will rise to
	public float column2_adj;
	public float column3_adj;
	public float column4_adj;

	public float goalHeight = -3.5f; //height of 1st ranked column;

	public string font = PlayerPrefs.GetString("font_name");
	public Text winningString;

	// Use this for initialization
	void Start () {
		GameObject sneakyFinds = GameObject.FindGameObjectWithTag("Player1");
		//winningString.font = Resources.Load<Font>(font);

		player1_rank = sneakyFinds.GetComponent<SneakyScript>().p1Rank;
		player2_rank = sneakyFinds.GetComponent<SneakyScript>().p2Rank;
		player3_rank = sneakyFinds.GetComponent<SneakyScript>().p3Rank;
		player4_rank = sneakyFinds.GetComponent<SneakyScript>().p4Rank;

		player1_rank = 1;
		player2_rank = 4;
		player3_rank = 2;
		player4_rank = 2;

		int p1 = PlayerPrefs.GetInt("player1_score");
		int p2 = PlayerPrefs.GetInt("player2_score");
		int p3 = PlayerPrefs.GetInt("player3_score");
		int p4 = PlayerPrefs.GetInt("player4_score");

		if (player1_rank == 1) {
			p1 += 5;
		} else if (player1_rank == 2) {
			p1 += 3;
		} else if (player1_rank == 3) {
			p1 += 1;
		} else {
			p1 += 0;
		}
		if (player2_rank == 1) {
			p2 += 5;
		} else if (player2_rank == 2) {
			p2 += 3;
		} else if (player2_rank == 3) {
			p2 += 1;
		} else {
			p2 += 0;
		}
		if (player3_rank == 1) {
			p3 += 5;
		} else if (player3_rank == 2) {
			p3 += 3;
		} else if (player3_rank == 3) {
			p3 += 1;
		} else {
			p3 += 0;
		}
		if (player4_rank == 1) {
			p4 += 5;
		} else if (player4_rank == 2) {
			p4 += 3;
		} else if (player4_rank == 3) {
			p4 += 1;
		} else {
			p4 += 0;
		}

		PlayerPrefs.SetInt ("player1_score", p1);
		PlayerPrefs.SetInt ("player2_score", p2);
		PlayerPrefs.SetInt ("player3_score", p3);
		PlayerPrefs.SetInt ("player4_score", p4);

		PlayerPrefs.Save ();

		/*
		column1_adj = -3.5f - player1_rank + 1f;
		column2_adj = -3.5f - player2_rank + 1f;
		column3_adj = -3.5f - player3_rank + 1f;
		column4_adj = -3.5f - player4_rank + 1f;
		*/
	}

	// Update is called once per frame
	void Update () {
		if (player1_rank == 1) {
			winningString.text = "Player 1 Wins!";
		} else if (player2_rank == 1) {
			winningString.text = "Player 2 Wins!";
		} else if (player3_rank == 1) {
			winningString.text = "Player 3 Wins!";
		} else {
			winningString.text = "Player 4 Wins!";
		}

		column1_adj = -3.5f - player1_rank + 1f;
		column2_adj = -3.5f - player2_rank + 1f;
		column3_adj = -3.5f - player3_rank + 1f;
		column4_adj = -3.5f - player4_rank + 1f;

		GameObject column1 = GameObject.Find ("Column1");
		GameObject column2 = GameObject.Find ("Column2");
		GameObject column3 = GameObject.Find ("Column3");
		GameObject column4 = GameObject.Find ("Column4");

		if (column1.transform.position.y <= column1_adj && (player1_rank != -1)) {
			column1.transform.position = new Vector3 (column1.transform.position.x, column1.transform.position.y + .05f, column1.transform.position.z);
		}
		if (column2.transform.position.y <= column2_adj && (player2_rank != -1)) {

			column2.transform.position = new Vector3 (column2.transform.position.x, column2.transform.position.y + .05f, column2.transform.position.z);
			//column2_adj += .05f;
		}
		if (column3.transform.position.y <= column3_adj && (player3_rank != -1)) {

			column3.transform.position = new Vector3(column3.transform.position.x, column3.transform.position.y + .05f, column3.transform.position.z);
			//column3_adj += .05f;
		}
		if (column4.transform.position.y <= column4_adj && (player4_rank != -1)) {
			column4.transform.position = new Vector3(column4.transform.position.x, column4.transform.position.y + .05f, column4.transform.position.z);
			//column4_adj += .05f;
		}
	}
}
