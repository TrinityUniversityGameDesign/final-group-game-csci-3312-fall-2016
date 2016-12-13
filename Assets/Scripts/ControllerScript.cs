using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    // a set of floats used to determine how long the main button list will be displayed
    // there is a base time of 2.5 seconds plus half a second per button
    // targetTime is decremented when the timer is active, and the timer is disabled when targetTime = 0
    private float baseTime = 2.5f;
    private float moreButtonsTime = .5f;
	private float targetTime = 5.0f;

    public int round; 
	public bool timerActive; // bool that indicates to player objects when they can take in inputs
	public GameObject canvas; // canvas game object, used to pull the MemoryDisplay script

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;


	// Use this for initialization
	void Start () {
        timerActive = false;
        round = 3; // we begin at round 3 because the number of buttons displayed = round
		canvas.GetComponent<MemoryDisplay> ().numButtons = round; // when the game begins, numButtons is set to round
		timerGenerator();


	}
	
	// Update is called once per frame
	void Update () {
		//grabbing the player1 from the scene (shouldn't be in the final script since we should be instantiating them)

		player1 = GameObject.FindGameObjectWithTag("Player1");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		player3 = GameObject.FindGameObjectWithTag("Player3");
		player4 = GameObject.FindGameObjectWithTag("Player4");

		//setting player's round
		if (player1 != null && player1.activeSelf) {
			var p1 = player1.GetComponent<PlayerScript> ();
			p1.setRound (round);
		}
		if (player2 != null && player2.activeSelf) {
			var p2 = player2.GetComponent<PlayerScript> ();
			p2.setRound (round);
		}
		if (player3 != null && player3.activeSelf) {
			var p3 = player3.GetComponent<PlayerScript> ();
			p3.setRound (round);
		}
		if (player4 != null && player4.activeSelf) {
			var p4 = player4.GetComponent<PlayerScript> ();
			p4.setRound (round);
		}

		canvas.GetComponent<MemoryDisplay> ().numButtons = round;

		if(timerActive)
		{
			targetTime -= Time.deltaTime;
			if (targetTime < 0)
			{
				timerActive = false;
				
			}
		}
	}

    // set the targetTime to the proper value depending on the round
    public void timerGenerator()
    {
        targetTime = baseTime + moreButtonsTime * round;
    }

    // called in MemoryDisplay, a way to logically move from one round to the next
    public void updateRounds()
    {
        timerActive = true;
        timerGenerator();

        // stop incrementing round after 9 as otherwise buttons flow offscreen
        // besides 9 buttons is plenty difficult lets not get too wet and wild here
        if (round < 9)
        {
            round += 1;
        }
    }
		
	IEnumerator waitBetween(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		print(Time.time);
	}


}
