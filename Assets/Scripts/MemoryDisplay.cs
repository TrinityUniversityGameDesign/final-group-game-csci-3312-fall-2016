using UnityEngine;
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

    public Text RandomInputText;
	public Text OutputText;

    int x = 0; // temp display number
	// Use this for initialization
	void Start () {
        getRandomInputs();
		player1 = GameObject.FindGameObjectWithTag ("Player1");
    }
	
	// Update is called once per frame
	void Update () {
        RandomInputText = GetComponent<Text>();
		OutputText = GameObject.Find ("PlayerText").GetComponent<Text>();
		PlayerList = player1.GetComponent<PlayerScript> ().InputList;
		if (PlayerList.Count >= Round) {
			ReturnList = compareInputs (PlayerList, InputList);
		}
		printOutputs (ReturnList);
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

            switch (tmp)
            {
                case Buttons.A:
                    message += "A ";
                    break;
                case Buttons.B:
                    message += "B ";
                    break;
                case Buttons.X:
                    message += "X ";
                    break;
                case Buttons.Y:
                    message += "Y ";
                    break;
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
