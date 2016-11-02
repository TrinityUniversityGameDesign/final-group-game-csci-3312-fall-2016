using UnityEngine;
using System.Collections;

public class AirBarScript : MonoBehaviour {
	Rect airRect;
	Texture2D airTexture;
	public string panelName;
	GameObject playerPanel;

	int heightAdjust;
	int maxBarWidth;

	int player;

	private int posX;
	private int posY;


	// Use this for initialization
	void Start () {


		if (player == 1) {
		}
		playerPanel = GameObject.Find (panelName) as GameObject;
		maxBarWidth = (int)playerPanel.GetComponent<RectTransform> ().rect.width;
		heightAdjust = (int)playerPanel.GetComponent<RectTransform> ().rect.height;

		airRect = new Rect (posX, posY, maxBarWidth, Screen.height/50);
		airTexture = new Texture2D (1, 1);
		airTexture.SetPixel (0, 0, Color.green);
		airTexture.Apply ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.DrawTexture (airRect, airTexture);
	}
}
