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

    // variables to keep track of where the ? buttons will be created when a button is pressed
	public Vector3 curButtonPos; 
	public Vector3 firstbuttonPos;

	public List<Buttons> InputList;

	void Awake() {
        alive = true;
        // set the proper input list variable, color, and button positions depending on player number
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
			hexColor = PlayerPrefs.GetString ("player4_color");
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
        // if you are alive and the main button list is not being shown...
        if (alive && !memDisp.butsAlive)
        {
            // if the player presses a button
            if (Input.GetButtonDown(iC.ABut))
            {
                // if the player's input list is not yet the size of the main button list
                if (InputList.Count < curRound) 
                {
                    // add the proper button to the input list and spawn a button next to the player
                    InputList.Add(Buttons.A);
                    spawnButton(Buttons.A);
                }
            }
            if (Input.GetButtonDown(iC.BBut))
            {
                if (InputList.Count < curRound)
                {
                    InputList.Add(Buttons.B);
                    spawnButton(Buttons.B);
                }
            }
            if (Input.GetButtonDown(iC.YBut))
            {
                if (InputList.Count < curRound)
                {
                    InputList.Add(Buttons.Y);
                    spawnButton(Buttons.Y);
                }
            }
            if (Input.GetButtonDown(iC.XBut))
            {
                if (InputList.Count < curRound)
                {
                    InputList.Add(Buttons.X);
                    spawnButton(Buttons.X);
                }
            }
        }
        // when the player dies, rotate them and send them heavenward
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

        // load in ? button prefab and instantiate it
		Object qButton =  Resources.Load("Prefabs/qButton");
		instance = (GameObject)Instantiate (qButton);

        // move through the player's input list
		var x = memDisp.InputList.GetEnumerator ();
		for (int i = 0; i < InputList.Count; ++i) {
			x.MoveNext ();
		}
		instance.GetComponent<ButtonScript> ().setValue (buttonVal, x.Current);

		if (InputList.Count == 1) {
			instance.transform.position = firstbuttonPos;
		} else {
			instance.transform.position = curButtonPos;
			instance.GetComponent<Rigidbody2D> ().AddForce (transform.up*200);
		}
			

	}
					
}
