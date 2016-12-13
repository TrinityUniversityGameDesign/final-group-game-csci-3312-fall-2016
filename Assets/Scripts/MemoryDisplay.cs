using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Buttons { A, B, X, Y }; // buttons that can be recognized

public class MemoryDisplay : MonoBehaviour {

	
	public List<Buttons> InputList = new List<Buttons>(); // list of inputs that will be memorized by player *remember to clear after every round

	public List<Buttons> PlayerList1 = new List<Buttons>();
	public List<Buttons> PlayerList2 = new List<Buttons>();
	public List<Buttons> PlayerList3 = new List<Buttons>();
	public List<Buttons> PlayerList4 = new List<Buttons>();

	public List<int> ReturnList1 = new List<int>();
	public List<int> ReturnList2 = new List<int>();
	public List<int> ReturnList3 = new List<int>();
	public List<int> ReturnList4 = new List<int>();

	public int numButtons = 5; // records how many 'rounds' have occured during the game
	public int rankCount;
	
    float displayTime = 2f;
    float timeBarPos = 0f;

    GameObject sneaky;
	public GameObject player1 = null;
	public GameObject player2 = null;
	public GameObject player3 = null;
	public GameObject player4 = null;
	GameObject TeachBoard;
    GameObject TeachColumn;
    string TeachString;

    // a whole mess of sprites for the backboard, changes to display the timer bar
    public GameObject boardBorder;
    public GameObject boardBG;
    public GameObject timerBar;
    public SpriteRenderer borderSR;
    public SpriteRenderer BGSR;
    public SpriteRenderer timerSR;
    public Sprite borderReg;
    public Sprite borderTime;
    public Sprite BGReg;
    public Sprite BGTime;

    // different button sprites
    public Object aButton;
	public Object bButton;
	public Object yButton;
	public Object xButton;
    public Object qButton;

    // location passed into spawning the buttons of the main list
	public Vector3 curButtonPos;

	public Text Player1ButtonCount;
    public Text Player2ButtonCount;
    public Text Player3ButtonCount;
    public Text Player4ButtonCount;

    // two debug objects that aren't used anymore
    public Text RandomInputText;
	public Text OutputText;

    Vector3 ColumnPos1;
    Vector3 ColumnPos2;
    Vector3 ColumnPos3;
    Vector3 ColumnPos4;

	public int numPlayers;
	public int numAlive;

    // bools used to determine what stage of the round it is
    public bool first = false; // 1st stage - display memory list, no input
	public bool second = false; // not a proper stage, just a signal to start reading inputs from the player
	public bool third = false; // the time where the main list isn't displayed and players can input
	public bool fourth = false; 
	public bool endScene = false;
    public bool butsAlive = false;
    int x = 0; // temp display number
	public GlobalPlayerControllerScript gameCont;
	
    // Use this for initialization
    void Start() {

        // find objects and load sprites
        sneaky = GameObject.Find("Sneaky");

		borderReg = Resources.Load ("Sprites/l0_board_1", typeof(Sprite)) as Sprite;
		borderTime = Resources.Load ("Sprites/l0_board_2", typeof(Sprite)) as Sprite;
		BGReg = Resources.Load ("Sprites/l1_board_1", typeof(Sprite)) as Sprite;
		BGTime = Resources.Load ("Sprites/l1_board_2", typeof(Sprite)) as Sprite;

		TeachBoard = GameObject.Find("TeachBoard");
        TeachColumn = GameObject.Find("TeachColumn");
        TeachString = PlayerPrefs.GetString("font_name");
        // TeachBoard.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), TeachString + ".ttf") as Font;
        // TeachColumn.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), TeachString + ".ttf") as Font;
		
		numPlayers = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GlobalPlayerControllerScript> ().num_players;
		numAlive = numPlayers;

        curButtonPos = new Vector3(-7, 0, 0);
        aButton = Resources.Load("Prefabs/aButton");
        bButton = Resources.Load("Prefabs/bButton");
        xButton = Resources.Load("Prefabs/xButton");
        yButton = Resources.Load("Prefabs/yButton");
        qButton = Resources.Load("Prefabs/qButton");

        player1 = GameObject.FindGameObjectWithTag("Player1");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		player3 = GameObject.FindGameObjectWithTag("Player3");
		player4 = GameObject.FindGameObjectWithTag("Player4");

		if (player2 != null && numPlayers <= 1) {
			player2.SetActive (false);
		}
		if (player3 != null && numPlayers <= 2) {	
			player3.SetActive (false);
		}
		if (player4 != null && numPlayers <= 3) {
			player4.SetActive (false);
		}


        // checks to see if a player is alive; if it is alive, rank is incremented
		rankCount = 0;
		if(player1.activeSelf) { rankCount++; }
		if(player2.activeSelf) { rankCount++; }
		if(player3.activeSelf) { rankCount++; }
		if(player4.activeSelf) { rankCount++; }
		
        boardBorder = GameObject.Find("board border");
        boardBG = GameObject.Find("board background");
        timerBar = GameObject.Find("timer bar");

        borderSR = boardBorder.GetComponent<SpriteRenderer>();
        BGSR = boardBG.GetComponent<SpriteRenderer>();
        timerSR = timerBar.GetComponent<SpriteRenderer>();

        first = true;
    }
	
	void Awake() { 
	gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>(); 
	}

	// Update is called once per frame
	void Update () {
        // if we are in the first stage make sure the board has the proper sprite and begin a new round
		if (first) {
            borderSR.sprite = borderReg;
            BGSR.sprite = BGReg;
            newRound();
			first = false;
			second = true;
		}
		if (second) {
            // set the memoryDisplay's player input list to the playerScript's player input list
            RandomInputText = GameObject.Find ("InputText").GetComponent<Text> ();
			OutputText = GameObject.Find ("PlayerText").GetComponent<Text> ();
			if (player1.activeSelf) {
				PlayerList1 = player1.GetComponent<PlayerScript> ().InputList;
			}
			if (player2.activeSelf) {
				PlayerList2 = player2.GetComponent<PlayerScript> ().InputList;
			}
			if (player3.activeSelf) {
				PlayerList3 = player3.GetComponent<PlayerScript> ().InputList;
			}
			if (player4.activeSelf) {
				PlayerList4 = player4.GetComponent<PlayerScript> ().InputList;
			}

				//GameObject.Find ("Main Camera").GetComponent<ControllerScript> ().updateRounds ();
				/*Debug.Log ("PENIS");
				if (PlayerList.Count >= numButtons) {
					ReturnList = compareInputs (PlayerList, InputList);
					float loss = ReturnList.Count * 10f;
					Debug.Log (loss);
					player1.GetComponent<PlayerScript> ().health -= loss;
				} */
			//printOutputs (ReturnList1);
			second = false;
			third = true;
		}
		if (third) {
            // if !butsAlive then the buttons are not being displayed, and it is time for players to input
            // actual player input is handled in PlayerScript, this is just updating the timer present in the main scene
            if (!butsAlive)
            {
                timerSR.enabled = true;
                borderSR.sprite = borderTime;
                BGSR.sprite = BGTime;

                // move the timer bar's position until it is offscreen, and then end the round
                if (timerBar.transform.position.x > -17f)
                {
                    timerBar.transform.position = new Vector2(timerBar.transform.position.x - 0.03f, timerBar.transform.position.y);
                }
            }
            else
            {
                // just a safety check to make sure the timer bar's sprite is in the right spot and hidden
                timerSR.enabled = false;
                timerBar.transform.position = new Vector2(0, timerBar.transform.position.y);
            }
			updatePlayerListCount();
            // if players are done with input, damage them for any mistakes and change ? buttons to the actual button pressed
            if (PlayersDone())
            {
				DamagePlayers();
				UpdateButtons ();
				third = false;
				fourth = true;
			}
		
		}

		if (fourth) {
			StartCoroutine(waitToUpdate(5f));
		}
		if (endScene) {
			SceneManager.LoadScene ("Scenes/PurpleParrotsEndingGameScene");
		}

        //StartCoroutine(timeToDisplay(x.ToString(), 2f));
    }

    // destroy the buttons after a delay, and if there is only one player left store ranks in sneaky and end the scene
	IEnumerator<WaitForSeconds> waitToUpdate(float delay){
		fourth = false;
		yield return new WaitForSeconds (delay);
		RemoveButtons ();
		if (numAlive <= 1) {
			if (player1.GetComponent<PlayerScript> ().alive) {
				sneaky.GetComponent<SneakyScript> ().p1Rank = 1;
			}
			if (player2.GetComponent<PlayerScript> ().alive) {
				sneaky.GetComponent<SneakyScript> ().p2Rank = 1;
			}
			if (player3.activeSelf && player3.GetComponent<PlayerScript> ().alive) {
				sneaky.GetComponent<SneakyScript> ().p3Rank = 1;
			}
			if (player4.activeSelf && player4.GetComponent<PlayerScript> ().alive) {
				sneaky.GetComponent<SneakyScript> ().p4Rank = 1;
			}
			endScene = true;
		} else {
			first = true;
		}

	}

	void RemoveButtons(){
		var list = GameObject.FindGameObjectsWithTag("Button");
		foreach (var a in list) {
			Destroy (a);
		}
	}

	void UpdateButtons(){
		var list = GameObject.FindGameObjectsWithTag("Button");
		foreach (var a in list) {
			a.GetComponent<ButtonScript> ().EndRound ();
		}
	}

    // lower player health, lower column height based on health, and if dead give player proper rank and store it in sneaky
	void DamagePlayer(GameObject player,GameObject column,int pnum){
		float loss = (float)compareInputs (player.GetComponent<PlayerScript> ().InputList, InputList).Count;
		player.GetComponent<PlayerScript>().health -= loss;
		column.transform.position = new Vector3(column.transform.position.x, column.transform.position.y - .5f * loss, column.transform.position.z);
		if (player.GetComponent<PlayerScript> ().health <= 0) {
			numAlive--;
			player.GetComponent<PlayerScript> ().alive = false;
			if (pnum == 1) {
				sneaky.GetComponent<SneakyScript>().p1Rank = rankCount;
				player.GetComponent<PlayerScript> ().rank = rankCount;
			}
			if (pnum == 2) {
				sneaky.GetComponent<SneakyScript>().p2Rank = rankCount;
				player2.GetComponent<PlayerScript> ().rank = rankCount;
			}
			if (pnum == 3) {
				sneaky.GetComponent<SneakyScript>().p3Rank = rankCount;
				player3.GetComponent<PlayerScript> ().rank = rankCount;
			}
			if (pnum == 4) {
				sneaky.GetComponent<SneakyScript>().p4Rank = rankCount;
				player4.GetComponent<PlayerScript> ().rank = rankCount;
			}
			rankCount -= 1;
		}
	}
	
	void DamagePlayers(){
		if(player1.activeSelf && player1.GetComponent<PlayerScript>().alive){
			DamagePlayer(player1, GameObject.Find("Column1"),1);
		}
		if(player2.activeSelf && player2.GetComponent<PlayerScript>().alive){
			DamagePlayer(player2, GameObject.Find("Column2"),2);
		}
		if(player3.activeSelf && player3.GetComponent<PlayerScript>().alive){
			DamagePlayer(player3, GameObject.Find("Column3"),3);
		}
		if(player4.activeSelf && player4.GetComponent<PlayerScript>().alive){
			DamagePlayer(player4, GameObject.Find("Column4"),4);
		}
		// if a player is not alive after receiving damage, it has died and should recieve a ranking
		// ranking is decremented after player(s) is ranked
	}
	
    // used for the display text at the bottom of each player's column
	void playerListCount(int playerListCount, Text countText)
    {
        countText.text = playerListCount.ToString() + "/" + InputList.Count.ToString();
    }

    void updatePlayerListCount()
    {
		if (player1.activeSelf && player1.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList1.Count, Player1ButtonCount);
        }
		if (player2.activeSelf && player2.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList2.Count, Player2ButtonCount);

        }
		if (player3.activeSelf && player3.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList3.Count, Player3ButtonCount);

        }
		if (player4.activeSelf && player4.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList4.Count, Player4ButtonCount);
        }
    }
	
    // end the period of player input after everyone has input everything or run out of time
	public bool PlayersDone(){

        // if the timer bar is offscreen then the input time has elapsed & the round ends
        if (timerBar.transform.position.x <= -16.8f)
        {
            return true;
        }

        // declare the round over if all 4 players have the correct number of inputs
		if(player1.activeSelf && player1.GetComponent<PlayerScript>().alive){

			if(PlayerList1.Count != (numButtons - 1)){
				playerListCount(PlayerList1.Count,Player1ButtonCount);
				return false;
			}
		}
		if(player2.activeSelf && player2.GetComponent<PlayerScript>().alive){
			if(PlayerList2.Count != (numButtons - 1)){
				playerListCount(PlayerList2.Count, Player2ButtonCount);
				return false;
			}
		}
		if(player3.activeSelf && player3.GetComponent<PlayerScript>().alive){
			if(PlayerList3.Count != (numButtons -1)){
				playerListCount(PlayerList3.Count, Player3ButtonCount);
				return false;
			}
		}
		if(player4.activeSelf && player4.GetComponent<PlayerScript>().alive){
			if(PlayerList4.Count != (numButtons -1)){
				playerListCount(PlayerList4.Count, Player4ButtonCount);
				return false;
			}
		}
		
		return true;
		
	}
	
    // call timeToDisplay upon round start
    // create the main list of buttons, wait, and then destroy them
    IEnumerator<WaitForSeconds> timeToDisplay(string message, float delay)
    {
        butsAlive = true;
        GameObject[] buttonObjList;
        RandomInputText.text = message;
        RandomInputText.enabled = true;
        yield return new WaitForSeconds(delay);
        buttonObjList = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < buttonObjList.Length; i++)
        {
            Destroy(buttonObjList[i]);
        }
        RandomInputText.enabled = false;
        x += 1;
        butsAlive = false;
    }

    void printOutputs(List<int> PassedList){
		string message = "";

		for (int i = 0; i < PassedList.Count; i++) {
			message += PassedList [i] + " "; 
		}

		OutputText.text = message;
		OutputText.enabled = true;
	}

    // gets inputs from generateRandomInputs
    // actually instantiates the list created in generateRandomInputs
    // compares inputs to create message and call timeToDisplay
	void getRandomInputs()
    {
        string message = "";

        generateRandomInputs(numButtons);

        for (int i = 0; i < InputList.Count; i++)
        {
            Buttons tmp = InputList[i];
			GameObject instance = null; 


            switch (tmp)
            {
			case Buttons.A:
					instance = (GameObject)Instantiate (aButton);
                    message += "A ";
                    break;
            case Buttons.B:
					instance =	(GameObject)Instantiate (bButton);
                    message += "B ";
                    break;
            case Buttons.X:
					instance =	(GameObject)Instantiate (xButton);
                    message += "X ";
                    break;
            case Buttons.Y:
					instance =	(GameObject)Instantiate (yButton);
                    message += "Y ";
                    break;
            }
			if (instance) {
				instance.transform.position = curButtonPos;
				curButtonPos = new Vector3 (curButtonPos.x + 1.75f, curButtonPos.y, curButtonPos.z); 
			}


        }

        //for(int i = 0; i < InputList.Count; i++)
        //{
        //    Debug.Log(InputList[i] + i.ToString());
        //}
        //Debug.Log(message);
        StartCoroutine(timeToDisplay(message, displayTime));
    }

    // generate the random list of buttons
    void generateRandomInputs(int roundNumber) {
		for (int i = 0; i < roundNumber; i++) {
			InputList.Add((Buttons)Random.Range (0, 4));
		}
	}


    //Returns a list of the indices where the player had the wrong button
    List<int> compareInputs(List<Buttons> playerInput, List<Buttons> correctInput)
    {
        int counter = 0;
        List<int> wrongInput = new List<int>(4);
        IEnumerator<Buttons> correctEnum = correctInput.GetEnumerator();
        IEnumerator<Buttons> playerEnum = playerInput.GetEnumerator();
        
        while (correctEnum.MoveNext())          //MoveNext returns true as long as the enumerator's on a valid element
        {
            playerEnum.MoveNext();
            if (correctEnum.Current != playerEnum.Current) { wrongInput.Add(counter); }
            ++counter;
        }
        return wrongInput;
    }

    // clear all player lists, reset the position that the button list will 
    // begin spawning at, and add to the display time for the next round
    void newRound()
    {
        displayTime += 0.5f;

		if (player1.activeSelf) {
			PlayerList1.Clear();
		}
		if (player2.activeSelf) {
			PlayerList2.Clear ();
		}
		if (player3.activeSelf) {
			PlayerList3.Clear ();
		}
		if (player4.activeSelf) {
			PlayerList4.Clear ();
		}
        InputList.Clear();
        var list = GameObject.FindGameObjectsWithTag("Button");
        curButtonPos = new Vector3(-7, 3.3f, 0);
        foreach (var a in list)
        {
            Destroy(a);
        }
        getRandomInputs();
        GameObject.Find("Main Camera").GetComponent<ControllerScript>().updateRounds();
    }

}
