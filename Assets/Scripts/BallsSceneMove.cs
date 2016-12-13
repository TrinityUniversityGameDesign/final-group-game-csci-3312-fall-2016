using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class BallsSceneMove : MonoBehaviour {
    public GlobalPlayerControllerScript gameCont;
    public float abutton;
	// Use this for initialization
	void Start () {
    }

    void Awake()
    {
        gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
        //abutton = Input.GetAxis(gameCont.players[0].ABut);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown(gameCont.player1_in.ABut) || Input.GetButtonDown(gameCont.player2_in.ABut) || Input.GetButtonDown(gameCont.player3_in.ABut) || Input.GetButtonDown(gameCont.player4_in.ABut))
        {
            SceneManager.LoadScene("Balls");
        }
	}
}
