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

    public Object aButton;
	public Object bButton;
	public Object yButton;
	public Object xButton;
    public Object qButton;

	public Vector3 curButtonPos;

	public Text Player1ButtonCount;
    public Text Player2ButtonCount;
    public Text Player3ButtonCount;
    public Text Player4ButtonCount;
    public Text RandomInputText;
	public Text OutputText;
    Vector3 ColumnPos1;
    Vector3 ColumnPos2;
    Vector3 ColumnPos3;
    Vector3 ColumnPos4;

    // bools used to determine what stage of the round it is
    public bool first = false; // 1st stage - display memory list, no input
	public bool second = false; // 2nd stage - hide memory list, player input
	public bool third = false; // 3rd stage - show both lists, comparison
    public bool butsAlive = false;
    int x = 0; // temp display number
	public GlobalPlayerControllerScript gameCont;
	
    // Use this for initialization
    void Start() {
        sneaky = GameObject.Find("Sneaky");
        TeachBoard = GameObject.Find("TeachBoard");
        TeachColumn = GameObject.Find("TeachColumn");
        TeachString = PlayerPrefs.GetString("font_name");
        TeachBoard.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), TeachString + ".ttf") as Font;
        TeachColumn.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), TeachString + ".ttf") as Font;
		
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

		// checks to see if a player is alive; if it is alive, rank is incremented
		rankCount = 0;
		if(player1.GetComponent<PlayerScript> ().alive) { rankCount++; }
		if(player2.GetComponent<PlayerScript> ().alive) { rankCount++; }
		if(player3.GetComponent<PlayerScript> ().alive) { rankCount++; }
		if(player4.GetComponent<PlayerScript> ().alive) { rankCount++; }
		
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
		if(SceneManager.GetActiveScene().name == "IntroScene")
        {
            if(Input.GetButtonDown(gameCont.player1_in.ABut))
            {
                SceneManager.LoadScene(6);
            }
        }
		if (first) {
            borderSR.sprite = borderReg;
            BGSR.sprite = BGReg;
            newRound();
			first = false;
			second = true;
		}
		if (second) {
            
            RandomInputText = GameObject.Find ("InputText").GetComponent<Text> ();
			OutputText = GameObject.Find ("PlayerText").GetComponent<Text> ();
			if (player1) {
				PlayerList1 = player1.GetComponent<PlayerScript> ().InputList;
				PlayerList2 = player2.GetComponent<PlayerScript> ().InputList;
				PlayerList3 = player3.GetComponent<PlayerScript> ().InputList;
				PlayerList4 = player4.GetComponent<PlayerScript> ().InputList;
				//GameObject.Find ("Main Camera").GetComponent<ControllerScript> ().updateRounds ();
				/*Debug.Log ("PENIS");
				if (PlayerList.Count >= numButtons) {
					ReturnList = compareInputs (PlayerList, InputList);
					float loss = ReturnList.Count * 10f;
					Debug.Log (loss);
					player1.GetComponent<PlayerScript> ().health -= loss;
				} */
				printOutputs (ReturnList1);
			}
			second = false;
			third = true;
		}
		if (third) {
            if (!butsAlive)
            {
                timerSR.enabled = true;
                borderSR.sprite = borderTime;
                BGSR.sprite = BGTime;
                if (timerBar.transform.position.x > -17f)
                {
                    timerBar.transform.position = new Vector2(timerBar.transform.position.x - 0.03f, timerBar.transform.position.y);
                }
            }
            else
            {
                timerSR.enabled = false;
                timerBar.transform.position = new Vector2(0, timerBar.transform.position.y);
            }
			updatePlayerListCount();
			//playersDone should just check the alive players' lists and the 
            if (PlayersDone()){
				DamagePlayers();
				first = true;
				third = false;
			}
		
		}

        //StartCoroutine(timeToDisplay(x.ToString(), 2f));
    }

	void DamagePlayer(GameObject player,GameObject column){
		float loss = (float)compareInputs (player.GetComponent<PlayerScript> ().InputList, InputList).Count;
		player.GetComponent<PlayerScript>().health -= loss;
		column.transform.position = new Vector3(column.transform.position.x, column.transform.position.y - .5f * loss, column.transform.position.z);
	}
	
	void DamagePlayers(){
		if(player1.GetComponent<PlayerScript>().alive){
			DamagePlayer(player1, GameObject.Find("Column1"));
		}
		if(player2.GetComponent<PlayerScript>().alive){
			DamagePlayer(player2, GameObject.Find("Column2"));
		}
		if(player3.GetComponent<PlayerScript>().alive){
			DamagePlayer(player3, GameObject.Find("Column3"));
		}
		if(player4.GetComponent<PlayerScript>().alive){
			DamagePlayer(player4, GameObject.Find("Column4"));
		}
		// if a player is not alive after receiving damage, it has died and should recieve a ranking
		int count = 0;
		if (player1.GetComponent<PlayerScript> ().alive == false) {
            sneaky.GetComponent<SneakyScript>().p1Rank = rankCount;
			player1.GetComponent<PlayerScript> ().rank = rankCount;
			count++;
		}
		if (player2.GetComponent<PlayerScript> ().alive == false) {
            sneaky.GetComponent<SneakyScript>().p2Rank = rankCount;
            player2.GetComponent<PlayerScript> ().rank = rankCount;
			count++;
		}
		if (player3.GetComponent<PlayerScript> ().alive == false) {
            sneaky.GetComponent<SneakyScript>().p3Rank = rankCount;
            player3.GetComponent<PlayerScript> ().rank = rankCount;
			count++;
		}
		if (player4.GetComponent<PlayerScript> ().alive == false) {
            sneaky.GetComponent<SneakyScript>().p4Rank = rankCount;
            player4.GetComponent<PlayerScript> ().rank = rankCount;
			count++;
		}
		rankCount -= count; // ranking is decremented after player(s) is ranked
	}
	
	void playerListCount(int playerListCount, Text countText)
    {
        countText.text = playerListCount.ToString() + "/" + InputList.Count.ToString();
    }

    void updatePlayerListCount()
    {
        if (player1.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList1.Count, Player1ButtonCount);
        }
        if (player2.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList2.Count, Player2ButtonCount);

        }
        if (player3.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList3.Count, Player3ButtonCount);

        }
        if (player4.GetComponent<PlayerScript>().alive)
        {
            playerListCount(PlayerList4.Count, Player4ButtonCount);
        }
    }
	
	public bool PlayersDone(){
        if (timerBar.transform.position.x <= -16.8f)
        {
            return true;
        }
        if (player1.GetComponent<PlayerScript>().alive){
			if(PlayerList1.Count != (numButtons - 1)){
				playerListCount(PlayerList1.Count,Player1ButtonCount);
				return false;
			}
		}
		if(player2.GetComponent<PlayerScript>().alive){
			if(PlayerList2.Count != (numButtons - 1)){
				playerListCount(PlayerList2.Count, Player2ButtonCount);
				return false;
			}
		}
		if(player3.GetComponent<PlayerScript>().alive){
			if(PlayerList3.Count != (numButtons -1)){
				playerListCount(PlayerList3.Count, Player3ButtonCount);
				return false;
			}
		}
		if(player4.GetComponent<PlayerScript>().alive){
			if(PlayerList4.Count != (numButtons -1)){
				playerListCount(PlayerList4.Count, Player4ButtonCount);
				return false;
			}
		}
		
		return true;
		
	}
	
    //call timeToDisplay upon round start
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

    //gets inputs from generateRandomInputs
    //compares inputs to create message and call timeToDisplay
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


    void newRound()
    {
        displayTime += 0.5f;
        PlayerList1.Clear();
		PlayerList2.Clear ();
		PlayerList3.Clear ();
		PlayerList4.Clear ();
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
