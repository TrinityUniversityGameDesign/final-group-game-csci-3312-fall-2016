using UnityEngine;
using System.Collections;

public class SelectSceneScript : MonoBehaviour {

	public bool isKeyboard;

	public GlobalPlayerControllerScript gameCont;

	public GameObject player1 = null;
	public GameObject player2 = null;
	public GameObject player3 = null;
	public GameObject player4 = null;

	void Awake(){
		//Should clear out player prefs' of the controller associated with it
		gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
	
	}

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag("Player1");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		player3 = GameObject.FindGameObjectWithTag("Player3");
		player4 = GameObject.FindGameObjectWithTag("Player4");
	}
	
	// Update is called once per frame

	//May need to mess with player prefs actually.
	//As in, store a string pair, so that we know whether or not Player1 is using keyboard, or if we need to shift down 

	void Update () {

		if (gameCont.player1_in == null) {
			if (Input.GetButtonDown ("A_P1")) {
				gameCont.player1_in = new PlayerInput("P1");
				isKeyboard = false;
				Debug.Log ("Controller Used");
				gameCont.num_players += 1;
			}
			if(Input.GetButtonDown("A_P1_KEYBOARD")){
				gameCont.player1_in = new PlayerInput("P1_KEYBOARD");
				isKeyboard = true;
				Debug.Log ("Keyboard Used");
				gameCont.num_players += 1;
			}

		}
		
		if(isKeyboard){
			if (gameCont.player2_in == null) {
				if(Input.GetButtonDown("A_P1")){
					gameCont.player2_in = new PlayerInput("P1");
					gameCont.num_players += 1;
				}
			}
			if (gameCont.player3_in == null) {
				if(Input.GetButtonDown("A_P2")){
					gameCont.player3_in = new PlayerInput("P2");
					gameCont.num_players += 1;
				}
			}
			if (gameCont.player4_in == null) {
				if(Input.GetButtonDown("A_P3")){
					gameCont.player4_in = new PlayerInput("P3");
					gameCont.num_players += 1;
				}
			}
		}
		else{
			if (gameCont.player2_in == null) {
				if(Input.GetButtonDown("A_P2")){
					gameCont.player2_in = new PlayerInput("P2");
					gameCont.num_players += 1;
				}
			}
			if (gameCont.player3_in == null) {
				if(Input.GetButtonDown("A_P3")){
					gameCont.player3_in = new PlayerInput("P3");
					gameCont.num_players += 1;
				}

			}
			if (gameCont.player4_in == null) {
				if(Input.GetButtonDown("A_P4")){
					gameCont.player4_in = new PlayerInput("P4");
					gameCont.num_players += 1;
				}
			}
		}


		if (gameCont.player1_in != null) {
			player1.GetComponent<SelectPlayerControls> ().iC = gameCont.player1_in;
			player1.GetComponent<SelectPlayerControls> ().active = true;
		}
		if (gameCont.player2_in != null) {
			player2.GetComponent<SelectPlayerControls> ().iC = gameCont.player2_in;
			player2.GetComponent<SelectPlayerControls> ().active = true;
		}
		if (gameCont.player3_in != null) {
			player3.GetComponent<SelectPlayerControls> ().iC = gameCont.player3_in;
			player3.GetComponent<SelectPlayerControls> ().active = true;
		}
		if (gameCont.player4_in != null) {
			player4.GetComponent<SelectPlayerControls> ().iC = gameCont.player4_in;
			player4.GetComponent<SelectPlayerControls> ().active = true;
		}

	



	}


}
