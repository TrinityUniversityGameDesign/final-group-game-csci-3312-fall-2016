using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriviaPlayer : MonoBehaviour
{
	public Text txtScore;
	public int score = 0;
	public int playerNumber;
	bool answered;
	public GameObject controllerGameObject;
	TrivaController controller;

	// Use this for initialization
	void Start ()
	{
		answered = false;
		controller = controllerGameObject.GetComponent<TrivaController> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		txtScore.text = "Score : " + score;
		if (!answered && controller.canIAnswer()) {
			
			if (Input.GetAxis ("A_P" + playerNumber) > 0) {
				answered = true;
				score += controller.amIRight ('a');
			} else if (Input.GetAxis ("X_P" + playerNumber) > 0) {
				answered = true;
				score += controller.amIRight ('x');
			}
			else if (Input.GetAxis ("B_P" + playerNumber) > 0) {
				answered = true;
				score += controller.amIRight ('b');
			}
			else if (Input.GetAxis ("Y_P" + playerNumber) > 0) {
				answered = true;
				score += controller.amIRight ('y');
			}
		}
	}
}
