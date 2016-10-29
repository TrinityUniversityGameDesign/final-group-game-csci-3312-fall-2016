using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MemoryDisplay : MonoBehaviour {

	public enum Buttons {A,B,X,Y}; // buttons that can be recognized
	List<Buttons> InputList; // list of inputs that will be memorized by player *remember to clear after every round
	private int Round = 0; // records how many 'rounds' have occured during the game

    public Text RandomInputText;
    int x = 0; // temp display number
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        
        RandomInputText.text = x.ToString();
        timeToDisplay();
	}

    void timeToDisplay()
    {
        x += 1;
    }

	void generateRandomInputs(int roundNumber) {
		for (int i = 0; i < roundNumber; i++) {
			InputList.push_back((Buttons)Random.Range (0, 3));
		}
	}

}
