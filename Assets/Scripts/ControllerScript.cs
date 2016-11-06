using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	private float targetTime = 0.0f;
    public int round = 0;
	public bool timerActive = false; // bool that indicates to player objects when they can take in inputs
	public GameObject canvas; // canvas game object, used to pull the MemoryDisplay script

	// Use this for initialization
	void Start () {
		canvas.GetComponent<MemoryDisplay> ().numButtons = round; // when the game begins, round is set to 0
		timerGenerator(round);
	}
	
	// Update is called once per frame
	void Update () {
		canvas.GetComponent<MemoryDisplay> ().numButtons = round;

		if(timerActive)
		{
			targetTime -= Time.deltaTime;
			if (targetTime < 0)
			{
				timerActive = false;
				round += 1;
			}
		}
	}

	void timerGenerator(int r) {
		targetTime = 5.0f;
	}
}
