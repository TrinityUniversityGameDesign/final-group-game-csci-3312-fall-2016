using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	Vector3 startButtonPos; 
	string buttonName = "";
	public SpriteRenderer spRend;
	public Sprite sp; 

	// Use this for initialization
	void Start () {
		spRend = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (buttonName != "") {
			sp = Resources.Load ("Resources/Sprites/"+buttonName,typeof(Sprite)) as Sprite;
		}
		/*if (GameObject.Find ("Canvas").GetComponent<MemoryDisplay> ().third) {
			spRend.sprite = sp;
			this.GetComponent<Rigidbody2D>().gravityScale = 1;
		}*/
	}

	public void setValue(string actualName){
		buttonName = actualName;
	}


}
