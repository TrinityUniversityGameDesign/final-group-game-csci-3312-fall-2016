using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SelectSceneScript : MonoBehaviour {

	public bool isKeyboard;

	public GlobalPlayerControllerScript gameCont;

	public GameObject canvas;

	public GameObject player1 = null;
	public GameObject player2 = null;
	public GameObject player3 = null;
	public GameObject player4 = null;

	public GameObject player1_Col = null;
	public GameObject player2_Col = null;
	public GameObject player3_Col = null;
	public GameObject player4_Col = null;

	public GameObject player1_Sliders;
	public GameObject player2_Sliders;
	public GameObject player3_Sliders;
	public GameObject player4_Sliders;

	public bool activated_p1;
	public bool activated_p2;
	public bool activated_p3;
	public bool activated_p4;

	public EventSystem eventSystem_p1;
	public EventSystem eventSystem_p2;
	public EventSystem eventSystem_p3;
	public EventSystem eventSystem_p4;

	void Awake(){
		//Should clear out player prefs' of the controller associated with it
		gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
		canvas = GameObject.Find ("Canvas");
	}

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag("Player1");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		player3 = GameObject.FindGameObjectWithTag("Player3");
		player4 = GameObject.FindGameObjectWithTag("Player4");

		player1_Col = GameObject.Find ("ColumnPlayer1");
		player2_Col = GameObject.Find ("ColumnPlayer2");
		player3_Col = GameObject.Find ("ColumnPlayer3");
		player4_Col = GameObject.Find ("ColumnPlayer4");

		player1.GetComponent<SelectPlayerControls>().playerCol = player1_Col;
		player2.GetComponent<SelectPlayerControls>().playerCol = player2_Col;
		player3.GetComponent<SelectPlayerControls>().playerCol = player3_Col;
		player4.GetComponent<SelectPlayerControls>().playerCol = player4_Col;


		eventSystem_p1 = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p1;
		eventSystem_p2 = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p2;
		eventSystem_p3 = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p3;
		eventSystem_p4 = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p4;

		player1_Sliders = GameObject.Find ("Player1Color");
		player1_Sliders.GetComponent<ColorPickerScript> ().player = player1;
		player1_Sliders.GetComponent<ColorPickerScript> ().redSlider = player1_Sliders.transform.Find ("RedSlider").GetComponent<Slider> ();
		player1_Sliders.GetComponent<ColorPickerScript> ().blueSlider = player1_Sliders.transform.Find ("BlueSlider").GetComponent<Slider> ();
		player1_Sliders.GetComponent<ColorPickerScript> ().greenSlider = player1_Sliders.transform.Find ("GreenSlider").GetComponent<Slider> ();

		player2_Sliders = GameObject.Find ("Player2Color");
		player2_Sliders.GetComponent<ColorPickerScript> ().player = player2;
		player2_Sliders.GetComponent<ColorPickerScript> ().redSlider = player2_Sliders.transform.Find ("RedSlider").GetComponent<Slider> ();
		player2_Sliders.GetComponent<ColorPickerScript> ().blueSlider = player2_Sliders.transform.Find ("BlueSlider").GetComponent<Slider> ();
		player2_Sliders.GetComponent<ColorPickerScript> ().greenSlider = player2_Sliders.transform.Find ("GreenSlider").GetComponent<Slider> ();

		player3_Sliders = GameObject.Find ("Player3Color");
		player3_Sliders.GetComponent<ColorPickerScript> ().player = player3;
		player3_Sliders.GetComponent<ColorPickerScript> ().redSlider = player3_Sliders.transform.Find ("RedSlider").GetComponent<Slider> ();
		player3_Sliders.GetComponent<ColorPickerScript> ().blueSlider = player3_Sliders.transform.Find ("BlueSlider").GetComponent<Slider> ();
		player3_Sliders.GetComponent<ColorPickerScript> ().greenSlider = player3_Sliders.transform.Find ("GreenSlider").GetComponent<Slider> ();

		player4_Sliders = GameObject.Find ("Player4Color");
		player4_Sliders.GetComponent<ColorPickerScript> ().player = player4;
		player4_Sliders.GetComponent<ColorPickerScript> ().redSlider = player4_Sliders.transform.Find ("RedSlider").GetComponent<Slider> ();
		player4_Sliders.GetComponent<ColorPickerScript> ().blueSlider = player4_Sliders.transform.Find ("BlueSlider").GetComponent<Slider> ();
		player4_Sliders.GetComponent<ColorPickerScript> ().greenSlider = player4_Sliders.transform.Find ("GreenSlider").GetComponent<Slider> ();

		activated_p1 = false;
		activated_p2 = false;
		activated_p3 = false;
		activated_p4 = false;
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


		if (gameCont.player1_in != null && !activated_p1) {
			player1.GetComponent<SelectPlayerControls> ().iC = gameCont.player1_in;
			player1.GetComponent<SelectPlayerControls> ().txt_Name = GameObject.Find ("Player1Name").GetComponent<Text>();
			player1.GetComponent<SelectPlayerControls> ().active = true;
			playerActivate (player1_Col);
			eventSystem_p1.GetComponent<NewEventSystem> ().player = player1;
			eventSystem_p1.GetComponent<NewEventSystem>().selection = GameObject.Find ("Player1Color").GetComponent<ColorPickerScript> ().redSlider.gameObject;
			activated_p1 = true;
		}
		if (gameCont.player2_in != null && !activated_p2) {
			player2.GetComponent<SelectPlayerControls> ().iC = gameCont.player2_in;
			player2.GetComponent<SelectPlayerControls> ().active = true;
			playerActivate (player2_Col);
			eventSystem_p2.GetComponent<NewEventSystem> ().player = player2;
			eventSystem_p2.GetComponent<NewEventSystem>().selection = GameObject.Find ("Player2Color").GetComponent<ColorPickerScript> ().redSlider.gameObject;
			activated_p2 = true;
		}
		if (gameCont.player3_in != null && !activated_p3) {
			player3.GetComponent<SelectPlayerControls> ().iC = gameCont.player3_in;
			player3.GetComponent<SelectPlayerControls> ().active = true;
			playerActivate (player3_Col);
			eventSystem_p3.GetComponent<NewEventSystem> ().player = player3;
			eventSystem_p3.GetComponent<NewEventSystem>().selection = GameObject.Find ("Player3Color").GetComponent<ColorPickerScript> ().redSlider.gameObject;
			activated_p3 = true;
		}
		if (gameCont.player4_in != null && !activated_p4) {
			player4.GetComponent<SelectPlayerControls> ().iC = gameCont.player4_in;
			player4.GetComponent<SelectPlayerControls> ().active = true;
			playerActivate (player4_Col);
			eventSystem_p4.GetComponent<NewEventSystem> ().player = player4;
			eventSystem_p4.GetComponent<NewEventSystem>().selection = GameObject.Find ("Player4Color").GetComponent<ColorPickerScript> ().redSlider.gameObject;
			activated_p4 = true;
		}





	}

	void playerActivate(GameObject col){
		col.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100);
	}

}
