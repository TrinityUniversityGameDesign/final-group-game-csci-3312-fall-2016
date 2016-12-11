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
	public bool ready;
	public bool cntDown;

	public string name;

	void Awake (){
		active = false;
		nameSet = false;
		colorSet = false;
		ready = false;
		cntDown = false;
	}

	// Use this for initialization
	void Start () {
		
	}

	public void setReady(){
		ready = !ready;
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			if (txt_Name != null) {
				txt_Name.text = name;
			}
			if (!nameSet && ready && cntDown) {
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
				if (Input.GetButtonDown (iC.LB)) {
					name += "lb";
				}
				if (Input.GetButtonDown (iC.RB)) {
					name += "rb";
				}
				if(Input.GetAxisRaw(iC.DPadX) < 0){
					name += "l";
				}
				if(Input.GetAxisRaw(iC.DPadX) > 0){
					name += "r";
				}
				if(Input.GetAxisRaw(iC.DPadY) < 0){
					name += "d";
				}
				if(Input.GetAxisRaw(iC.DPadY) > 0){
					name += "u";
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
