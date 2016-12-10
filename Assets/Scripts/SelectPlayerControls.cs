using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectPlayerControls : MonoBehaviour {

	public GameObject playerCol;
	public PlayerInput iC; 

	public ColorPickerScript colorPicker;
	public GameObject selected;
	public Text txt_Name;

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
			if (txt_Name != null) {
				txt_Name.text = name;
			}
			if (!nameSet) {
				if (Input.GetButtonDown (iC.ABut)) {
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
				if (name.Length > 0) {
					if (Input.GetButtonDown (iC.backBut)) {
						name = name.Substring (0, name.Length - 1);
					}
				}
			} else {
				if (colorPicker != null && !colorSet) {
					if (selected == null) {
						selected = colorPicker.redSlider.gameObject;
					}
				}
			}
		
		}

	}


}
