using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {
		GameObject sneakyFinds = GameObject.FindGameObjectWithTag("Player1");

		player1_rank = sneakyFinds.GetComponent<SneakyScript>().p1Rank;
		player2_rank = sneakyFinds.GetComponent<SneakyScript>().p2Rank;
		player3_rank = sneakyFinds.GetComponent<SneakyScript>().p3Rank;
		player4_rank = sneakyFinds.GetComponent<SneakyScript>().p4Rank;

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
		}

		/*
		if (player1_rank != -1) {
			GameObject column1 = GameObject.Find ("Column1");
			column1.transform.position = new Vector3 (column1.transform.position.x, column1.transform.position.y + 1, column1.transform.position.z);
		}
		if (player2_rank != -1) {
			GameObject column2 = GameObject.Find ("Column2");
			column2.transform.position = new Vector3 (column2.transform.position.x, column2.transform.position.y + 1, column2.transform.position.z);
		}
		if (player3_rank != -1) {
			GameObject column3 = GameObject.Find ("Column3");
			column3.transform.position = new Vector3 (column3.transform.position.x, column3.transform.position.y + 1, column3.transform.position.z);
		}
		if (player4_rank != -1) {
			GameObject column4 = GameObject.Find ("Column4");
			column4.transform.position = new Vector3 (column4.transform.position.x, column4.transform.position.y + 1, column4.transform.position.z);
		}
		*/

		column1_adj = -3.5f - player1_rank + 1f; 
		column2_adj = -3.5f - player2_rank + 1f;
		column3_adj = -3.5f - player3_rank + 1f;
		column4_adj = -3.5f - player4_rank + 1f;
	}
	
	// Update is called once per frame
	void Update () {
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
