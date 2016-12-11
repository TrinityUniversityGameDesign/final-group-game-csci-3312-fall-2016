using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerScript : MonoBehaviour {
	public string playerNum;

	public PlayerInput iC; 
	public MemoryDisplay memDisp; 
	public SpriteRenderer spriteRend;
	public string hexColor;
	public Color player_color;

	public int curRound;
	public float health = 5.0f;
    public bool alive;
	public int rank;

	public Vector3 curButtonPos; 
	public Vector3 firstbuttonPos;

	public List<Buttons> InputList;
	// Use this for initialization

	void Awake() {
        alive = true;
		if (this.tag == "Player1") {
			iC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>().player1_in;
			hexColor = PlayerPrefs.GetString ("player1_color");
			firstbuttonPos = new Vector3(-8,-2,0);
			curButtonPos = new Vector3 (-8, -4, 0);
		}
		else if (this.tag == "Player2") {
			iC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>().player2_in;
			hexColor = PlayerPrefs.GetString ("player2_color");
			firstbuttonPos = new Vector3(-4.3f,-2,0);
			curButtonPos = new Vector3 (-4.3f, -4, 0);
		}
		else if (this.tag == "Player3") {
			iC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>().player3_in;
			hexColor = PlayerPrefs.GetString ("player3_color");
			firstbuttonPos = new Vector3(4.3f,-2,0);
			curButtonPos = new Vector3 (4.3f, -4, 0);
		}
		else if (this.tag == "Player4") {
			iC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>().player4_in;
			firstbuttonPos = new Vector3(8,-2,0);
			curButtonPos = new Vector3 (8,-4,0);
		}
		//Getting the Sprite Renderer for the shirt 
		spriteRend = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

	}

	void Start () {
		memDisp = GameObject.Find ("Canvas").GetComponent<MemoryDisplay>();
		InputList = new List<Buttons> ();
		ColorUtility.TryParseHtmlString (hexColor,out player_color);
		spriteRend.color = player_color;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) { alive = false; }
        if (alive && !memDisp.butsAlive)
        {
            if (Input.GetButtonDown(iC.ABut))
            {
                if (InputList.Count < curRound - 1)
                {
                    InputList.Add(Buttons.A);
                    spawnButton(Buttons.A);
                }
            }
            if (Input.GetButtonDown(iC.BBut))
            {
                if (InputList.Count < curRound - 1)
                {
                    InputList.Add(Buttons.B);
                    spawnButton(Buttons.B);
                }
            }
            if (Input.GetButtonDown(iC.YBut))
            {
                if (InputList.Count < curRound - 1)
                {
                    InputList.Add(Buttons.Y);
                    spawnButton(Buttons.Y);
                }
            }
            if (Input.GetButtonDown(iC.XBut))
            {
                if (InputList.Count < curRound - 1)
                {
                    InputList.Add(Buttons.X);
                    spawnButton(Buttons.X);
                }
            }
        }
        if (!alive) 
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 90f);
        }
        //if (GameObject.Find("Main Camera").GetComponent<MemoryDisplay>().InputList.Count())
        
        


	}
	
	public void setRound(int round){
		curRound = round;
	}

	public void spawnButton(Buttons buttonVal){
		GameObject instance = null; 
		 

		//Need a spawn point for each player

		Object qButton =  Resources.Load("Prefabs/qButton");
		instance = (GameObject)Instantiate (qButton);

	

		if (buttonVal == Buttons.A) {
			instance.GetComponent<ButtonScript> ().setValue("button_A");
		}
		else if (buttonVal == Buttons.B) {
			instance.GetComponent<ButtonScript> ().setValue("button_B");
		}
		else if (buttonVal == Buttons.X) {
			instance.GetComponent<ButtonScript> ().setValue("button_X");
		}
		else if (buttonVal == Buttons.Y) {
			instance.GetComponent<ButtonScript> ().setValue("button_Y");
		}
		if (InputList.Count == 1) {
			instance.transform.position = firstbuttonPos;
		} else {
			instance.transform.position = curButtonPos;
			instance.GetComponent<Rigidbody2D> ().AddForce (transform.up*200);
		}
			

	}
					
}
