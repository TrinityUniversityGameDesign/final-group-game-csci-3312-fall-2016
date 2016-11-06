﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public enum Buttons { A, B, X, Y }; // buttons that can be recognized

public class MemoryDisplay : MonoBehaviour {

	
	public List<Buttons> InputList = new List<Buttons>(); // list of inputs that will be memorized by player *remember to clear after every round
	public List<Buttons> PlayerList = new List<Buttons>();
	public List<int> ReturnList = new List<int>();
	public int Round = 5; // records how many 'rounds' have occured during the game
    float displayTime = 2f;
	public GameObject player1 = null;

	public Object aButton;
	public Object bButton;
	public Object yButton;
	public Object xButton;

	public Vector3 curButtonPos;

    public Text RandomInputText;
	public Text OutputText;

    int x = 0; // temp display number
	// Use this for initialization
	void Start () {
		curButtonPos = new Vector3 (-7, 0, 0);
		aButton =  Resources.Load("Prefabs/aButton");
		bButton =  Resources.Load("Prefabs/bButton");
		xButton =  Resources.Load("Prefabs/xButton");
		yButton =  Resources.Load("Prefabs/yButton");
        getRandomInputs();
		player1 = GameObject.FindGameObjectWithTag ("Player1");

    }
	
	// Update is called once per frame
	void Update () {
		RandomInputText = GameObject.Find ("InputText").GetComponent<Text>();
		OutputText = GameObject.Find ("PlayerText").GetComponent<Text>();
		if (player1) {
			PlayerList = player1.GetComponent<PlayerScript> ().InputList;
			if (PlayerList.Count >= Round) {
				ReturnList = compareInputs (PlayerList, InputList);
			}
			printOutputs (ReturnList);
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

        generateRandomInputs(5);

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
			InputList.Add((Buttons)Random.Range (0, 3));
		}
	}

    List<int> compareInputs(List<Buttons> playerInput, List<Buttons> correctInput)
    {
        int counter = 0;
        List<int> wrongInput = new List<int>(4);
        IEnumerator<Buttons> correctEnum = correctInput.GetEnumerator();
        IEnumerator<Buttons> playerEnum = playerInput.GetEnumerator();
        
        while (correctEnum.MoveNext())
        {
            playerEnum.MoveNext();
            if (correctEnum.Current != playerEnum.Current) { wrongInput.Add(counter); }
            ++counter;
        }
        return wrongInput;
    }

}
