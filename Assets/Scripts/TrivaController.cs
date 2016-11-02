using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrivaController : MonoBehaviour {
	public Color Highest;
	public Color Lowest;
	public Text txtScore;
	int question = 1;
	int score = 1000;
	public GameObject controller;
	public Image scoreBar;
	private int readTime = 150;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		txtScore.text = score.ToString();

		if (readTime == 0 && score > 1)
			score -= 2;
		else if (readTime > 0)
			readTime--;
		scoreBar.fillAmount = (score / 1000f);
		txtScore.color = Color.Lerp (Lowest, Highest, scoreBar.fillAmount);
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
	public bool canIAnswer(){
		if (readTime == 0 && score > 0)
			return true;
		else
			return false;
	}
}
