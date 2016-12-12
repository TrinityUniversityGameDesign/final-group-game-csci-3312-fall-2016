using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class IntroControllerScript : MonoBehaviour {
	private int mode = 0;
	public Button referenceToTheButton;
	public GameObject SmackText;
	public GameObject BowlMec;
	public GameObject InstructionText;
	public List<GameObject> cleaning;

	private Vector3 InstructionTextPosition;
	private Vector3 BowlMecPosition;
	private Vector3 dump;

    public GlobalPlayerControllerScript gameCont;
    void Awake() { gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>(); }

    // Use this for initialization
    void Start () {
		dump = new Vector3(1000,1000,1000);
		BowlMecPosition = BowlMec.transform.position;
		BowlMec.transform.position = dump;

		InstructionTextPosition = InstructionText.transform.position;
		InstructionText.transform.position = dump;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(gameCont.player1_in.ABut) && mode == 0) {
			SmackText.transform.position = dump;
			BowlMec.transform.position = BowlMecPosition;
			InstructionText.transform.position = InstructionTextPosition;
			mode++;
		} else if (Input.GetButtonDown(gameCont.player1_in.ABut) && mode == 1) {
			referenceToTheButton.onClick.Invoke();
			/*SceneManager.LoadScene ("DemoScene", LoadSceneMode.Additive);
			Destroy (BowlMec);
			Destroy (SmackText);
			Destroy (InstructionText);
			Destroy (cleaning [0]);
			Destroy (cleaning [1]);
			mode++;*/
		}
	}
}
