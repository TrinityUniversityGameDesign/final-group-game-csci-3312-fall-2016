using UnityEngine;
using System.Collections;

public class ButtonImageRef {
	public static string A_but = "Sprites/button_A";
	public static string B_but = "Sprites/button_B";
	public static string X_but = "Sprites/button_X";
	public static string Y_but = "Sprites/button_Y";
	public static string quest_but = "Sprites/button_question";
	public static string wrong_but = "Sprites/button_wrong";

	public string A{ get { return A_but; } }
	public string B{ get { return B_but; } }
	public string X{ get { return X_but; } }
	public string Y{ get { return Y_but; } }
	public string quest{ get { return quest_but; } }
	public string wrong{ get { return wrong_but; } }
}

public class ButtonScript : MonoBehaviour {
	public ButtonImageRef imgRef; 

	Vector3 startButtonPos; 

	public Buttons buttonName;
	public Buttons listButton;
	public SpriteRenderer spRend;
	public Sprite sp; 

	void Awake(){
		imgRef = new ButtonImageRef();
		spRend = this.GetComponent<SpriteRenderer> ();
	}
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		/*if (buttonName != "") {
			sp = Resources.Load ("Resources/Sprites/"+buttonName,typeof(Sprite)) as Sprite;
		}
		*/
		/*if (GameObject.Find ("Canvas").GetComponent<MemoryDisplay> ().third) {
			spRend.sprite = sp;
			this.GetComponent<Rigidbody2D>().gravityScale = 1;
		}*/
	}

public void EndRound(){
		if (buttonName != listButton) {
			sp = Resources.Load (imgRef.wrong, typeof(Sprite)) as Sprite;
			spRend.sprite = sp;
		} else {
			string ls = setSprite (buttonName);
			sp = Resources.Load (ls, typeof(Sprite)) as Sprite;
			spRend.sprite = sp;
		}
		GetComponent<Rigidbody2D> ().gravityScale = 1;
}

public string setSprite(Buttons inp){
	if (inp == Buttons.A) {
		return imgRef.A;
	}
	if (inp == Buttons.B) {
		return imgRef.B;
	}
	if (inp == Buttons.X) {
		return imgRef.X;
	}
	if (inp == Buttons.Y) {
		return imgRef.Y;
	} 
	else {
		return imgRef.quest;
	}

}

public void setValue(Buttons actualName, Buttons actualList){
		buttonName = actualName;
		listButton = actualList;
	}


}
