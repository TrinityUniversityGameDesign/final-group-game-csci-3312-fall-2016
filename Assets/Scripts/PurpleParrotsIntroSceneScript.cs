using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PurpleParrotsIntroSceneScript : MonoBehaviour {

	public GlobalPlayerControllerScript gameCont;

	void Awake(){
		gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            // if player 1 presses A, move onto the main scene
			if(Input.GetButtonDown(gameCont.player1_in.ABut))
			{
				SceneManager.LoadScene("Scenes/MainScene");
			}
	}

}
