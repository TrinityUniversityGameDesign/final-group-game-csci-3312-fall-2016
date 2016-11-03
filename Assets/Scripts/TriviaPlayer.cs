using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriviaPlayer : MonoBehaviour
{
	private Image Button;
	public Image A;
	public Image X;
	public Image B;
	public Image Y;
	public Image none;
	public Image check;
	public Text txtScore;
	public int preScore = 0;
	public int scoreFromQuestion = 0;
	public int playerNumber;
	bool answered;
	public GameObject controllerGameObject;
	TrivaController controller;

	// Use this for initialization
	void Start ()
	{
		Button = none;
		answered = false;
		controller = controllerGameObject.GetComponent<TrivaController> ();
		check.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (answered)
			check.fillAmount = 1;
		if (controller.questionIsDone ()) {
			check.sprite = Button.sprite;
			preScore += scoreFromQuestion;
			scoreFromQuestion = 0;
		}
		txtScore.text = "Score : " + preScore;
		if (!answered && controller.canIAnswer ()) {
			if (Input.GetAxis ("A_P" + playerNumber) > 0) {
				Button = A;
				answered = true;
				scoreFromQuestion = controller.amIRight ('a');
			} else if (Input.GetAxis ("X_P" + playerNumber) > 0) {
				Button = X;
				answered = true;
				scoreFromQuestion = controller.amIRight ('x');
			} else if (Input.GetAxis ("B_P" + playerNumber) > 0) {
				Button = B;
				answered = true;
				scoreFromQuestion = controller.amIRight ('b');
			} else if (Input.GetAxis ("Y_P" + playerNumber) > 0) {
				Button = Y;
				answered = true;
				scoreFromQuestion = controller.amIRight ('y');
			}
		}
	}
}
