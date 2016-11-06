using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	private float targetTime = 0.0f;
	public bool timerActive = false; // bool that indicates to player objects when they can take in inputs
	public GameObject canvas; // canvas game object, used to pull the MemoryDisplay script

	// Use this for initialization
	void Start () {
		canvas.GetComponent<MemoryDisplay> ().Round = 0; // when the game begins, round is set to 0
		timerGenerator(canvas.GetComponent<MemoryDisplay> ().Round);
	}
	
	// Update is called once per frame
	void Update () {
		int round = canvas.GetComponent<MemoryDisplay> ().Round;

		if(timerActive)
		{
			targetTime -= Time.deltaTime;
			if (targetTime < 0)
			{
				timerActive = false;
				canvas.GetComponent<MemoryDisplay> ().Round = round + 1;
			}
		}
	}

	void timerGenerator(int r) {
		targetTime = 5.0f;
	}
}
