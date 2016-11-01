using UnityEngine;
using System.Collections;

public class TrivaController : MonoBehaviour {
	int question = 1;
	int score = 1000;
	public GameObject controller;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score -= 3;
	}
	public int amIRight(char answer){
		if (question == 1) {
			if (answer == 'a')
				return score;
			else
				return 0;
		} else
			return 0;
	}

}
