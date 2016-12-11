using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class MyButton : Button {
	public EventSystem eventSystem;
	public Color highlighted;
	public Color pressed; 

	protected override void Awake(){
		base.Awake ();
		if (this.transform.parent.name == "Player1Color") {
			eventSystem = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p1;
		}
		if (this.transform.parent.name == "Player2Color") {
			eventSystem = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p2;
		}
		if (this.transform.parent.name == "Player3Color") {
			eventSystem = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p3;
		}
		if (this.transform.parent.name == "Player4Color") {
			eventSystem = GameObject.Find("EventSystemProvider").GetComponent<EventSystemProvider> ().eventSystem_p4;
		}
	}

	public override void Select(){

		if (eventSystem.alreadySelecting) {
			return;
		}

		eventSystem.SetSelectedGameObject (gameObject);
	}
}
