using UnityEngine;
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

		player1 = GameObject.Find ("Player1");

		//setting player's round
		var x = player1.GetComponent<PlayerScript> ();
		x.setRound (round);

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
