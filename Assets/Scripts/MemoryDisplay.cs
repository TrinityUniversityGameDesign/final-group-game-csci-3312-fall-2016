using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryDisplay : MonoBehaviour {

	public enum Buttons {A,B,X,Y}; // buttons that can be recognized
	List<Buttons> InputList; // list of inputs that will be memorized by player
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

}
