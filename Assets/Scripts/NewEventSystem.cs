using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NewEventSystem : EventSystem {


	public StandaloneInputModule sim;
	public GameObject selection; 
	public GameObject player;
	public bool setControls = false; 

	protected override void Awake(){
		player = null;
	}

	protected override void OnEnable(){
		
	}

	protected override void Update(){
		EventSystem originalCurrent = EventSystem.current; 
		current = this;
		base.Update();
		current = originalCurrent;
		if (sim == null) {
			sim = GetComponent<StandaloneInputModule> ();
		}
		if (player != null && !setControls && sim != null) {
			sim.horizontalAxis = player.GetComponent<SelectPlayerControls> ().iC.hor;
			sim.verticalAxis = player.GetComponent<SelectPlayerControls> ().iC.vert;
			sim.submitButton = player.GetComponent<SelectPlayerControls> ().iC.startBut;
			sim.cancelButton = player.GetComponent<SelectPlayerControls> ().iC.backBut;
			setControls = true;
			this.SetSelectedGameObject(selection);
		}

		if (setControls && currentSelectedGameObject == null) {
			SetSelectedGameObject(selection);
		}

	}



}

