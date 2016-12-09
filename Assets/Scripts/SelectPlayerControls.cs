using UnityEngine;
using System.Collections;

public class SelectPlayerControls : MonoBehaviour {
	public PlayerInput iC; 
	public bool active;
	public bool nameSet;
	public bool colorSet;

	public string name;

	void Awake (){
		active = false;
		nameSet = false;
		colorSet = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (!nameSet) {
				if(Input.GetButtonDown(iC.ABut)){
					name += "a";
				}
				if (Input.GetButtonDown (iC.BBut)) {
					name += "b";
				}
				if (Input.GetButtonDown (iC.YBut)) {
					name += "y";
				}
				if (Input.GetButtonDown (iC.XBut)) {
					name += "x";
				}
				if (Input.GetButtonDown (iC.startBut)) {
					nameSet = true;
				}
				if (Input.GetButtonDown (iC.backBut)) {
					name.Remove (name.Length-1, 1);
				}
			}
		
		}

	}


}
