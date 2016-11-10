﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum Buttons { A, B, X, Y }; // buttons that can be recognized

public class MemoryDisplay : MonoBehaviour {

	
	public List<Buttons> InputList = new List<Buttons>(); // list of inputs that will be memorized by player *remember to clear after every round
<<<<<<< Updated upstream
	public List<Buttons> PlayerList = new List<Buttons>();
	public List<int> ReturnList = new List<int>();
	public int numButtons; // records how many 'rounds' have occured during the game
=======
	public List<Buttons> PlayerList1 = new List<Buttons>();
	public List<Buttons> PlayerList2 = new List<Buttons>();
	public List<Buttons> PlayerList3 = new List<Buttons>();
	public List<Buttons> PlayerList4 = new List<Buttons>();
	public List<int> ReturnList1 = new List<int>();
	public List<int> ReturnList2 = new List<int>();
	public List<int> ReturnList3 = new List<int>();
	public List<int> ReturnList4 = new List<int>();
	public int numButtons = 5; // records how many 'rounds' have occured during the game
>>>>>>> Stashed changes
    float displayTime = 2f;
	public GameObject player1 = null;
	public GameObject player2 = null;
	public GameObject player3 = null;
	public GameObject player4 = null;

	public Object aButton;
	public Object bButton;
	public Object yButton;
	public Object xButton;
    public Object qButton;

	public Vector3 curButtonPos;

    public Text RandomInputText;
	public Text OutputText;

	// bools used to determine what stage of the round it is
	public bool first = false; // 1st stage - display memory list, no input
	public bool second = false; // 2nd stage - hide memory list, player input
	public bool third = false; // 3rd stage - show both lists, comparison

    int x = 0; // temp display number
	// Use this for initialization
	void Start () {
		curButtonPos = new Vector3 (-7, 0, 0);
		aButton =  Resources.Load("Prefabs/aButton");
		bButton =  Resources.Load("Prefabs/bButton");
		xButton =  Resources.Load("Prefabs/xButton");
		yButton =  Resources.Load("Prefabs/yButton");
        qButton =  Resources.Load("Prefabs/qButton");
        
		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
		player3 = GameObject.FindGameObjectWithTag ("Player3");
		player4 = GameObject.FindGameObjectWithTag ("Player4");

		first = true;

    }
	
	// Update is called once per frame
	void Update () {
		if (first) {
			newRound ();
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
			
			if (PlayerList1.Count == (numButtons - 1)) {
				ReturnList1 = compareInputs (PlayerList1, InputList);
				float loss = ReturnList1.Count;
				Debug.Log (loss);
				player1.GetComponent<PlayerScript> ().health -= loss;
				first = true;
				third = false;
			}
			if (PlayerList2.Count == (numButtons - 1)) {
				ReturnList2 = compareInputs (PlayerList2, InputList);
				float loss = ReturnList1.Count;
				Debug.Log (loss);
				player2.GetComponent<PlayerScript> ().health -= loss;
				first = true;
				third = false;
			}
			if (PlayerList3.Count == (numButtons - 1)) {
				ReturnList3 = compareInputs (PlayerList3, InputList);
				float loss = ReturnList3.Count;
				Debug.Log (loss);
				player3.GetComponent<PlayerScript> ().health -= loss;
				first = true;
				third = false;
			}
			if (PlayerList4.Count == (numButtons - 1)) {
				ReturnList4 = compareInputs (PlayerList4, InputList);
				float loss = ReturnList4.Count;
				Debug.Log (loss);
				player4.GetComponent<PlayerScript> ().health -= loss;
				first = true;
				third = false;
			}
			//if (GameObject.Find("Main Camera").GetComponent<ControllerScript>().timerActive == false)
			//{
				//StartCoroutine
				//first = true;
				//third = false;
			//}
		}

        //StartCoroutine(timeToDisplay(x.ToString(), 2f));
    }

    //call timeToDisplay upon round start
    IEnumerator<WaitForSeconds> timeToDisplay(string message, float delay)
    {
        RandomInputText.text = message;
        RandomInputText.enabled = true;
        yield return new WaitForSeconds(delay);
        //RandomInputText.enabled = false;
        x += 1;
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
				curButtonPos = new Vector3 (curButtonPos.x + 1, curButtonPos.y, curButtonPos.z); 
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
        PlayerList1.Clear();
		PlayerList2.Clear ();
		PlayerList3.Clear ();
		PlayerList4.Clear ();
        InputList.Clear();
        var list = GameObject.FindGameObjectsWithTag("Button");
        curButtonPos = new Vector3(-7, 0, 0);
        foreach (var a in list)
        {
            Destroy(a);
        }
        getRandomInputs();
        GameObject.Find("Main Camera").GetComponent<ControllerScript>().updateRounds();
    }

}
