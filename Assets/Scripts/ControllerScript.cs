﻿using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

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
        round = 5;
		canvas.GetComponent<MemoryDisplay> ().numButtons = round; // when the game begins, round is set to round
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
		var p1 = player1.GetComponent<PlayerScript> ();
		var p2 = player2.GetComponent<PlayerScript> ();
		var p3 = player3.GetComponent<PlayerScript> ();
		var p4 = player4.GetComponent<PlayerScript> ();
		p1.setRound (round);
		p2.setRound (round);
		p3.setRound (round);
		p4.setRound (round);

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

    public void timerGenerator()
    {
        targetTime = baseTime + moreButtonsTime * round;
    }

    public void updateRounds()
    {
        timerActive = true;
        timerGenerator();
        round += 1;
    }
		
	IEnumerator waitBetween(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		print(Time.time);
	}


}