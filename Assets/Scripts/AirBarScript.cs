﻿using UnityEngine;
using System.Collections;

public class AirBarScript : MonoBehaviour {
	Rect airRect;
	Texture2D airTexture;
	public string panelName;
	GameObject playerPanel;

	GameObject playerObject;

	int heightAdjust;
	int maxBarWidth;

	public int playerNum;

	private int posX;
	private int posY;

	private float currentBarWidth;


	// Use this for initialization
	void Start () {
		
		currentBarWidth = 0;
		playerPanel = GameObject.Find (panelName) as GameObject;
		maxBarWidth = (int)playerPanel.GetComponent<RectTransform> ().rect.width;
		heightAdjust = (int)playerPanel.GetComponent<RectTransform> ().rect.height;
		if (playerNum == 1) {
			posX = 0;
			posY = 0;
		} else if (playerNum == 2) {
			posX = Screen.width - maxBarWidth;
			posY = 0;
		} else if (playerNum == 3) {
			posX = 0;
			posY = Screen.height - heightAdjust;
		} else if (playerNum == 4) {
			posX = Screen.width - maxBarWidth;
			posY = Screen.height - heightAdjust;
		}


		airRect = new Rect (posX, posY, maxBarWidth, Screen.height/50);
		airTexture = new Texture2D (1, 1);
		airTexture.SetPixel (0, 0, Color.green);
		airTexture.Apply ();

		playerObject = playerPanel.GetComponent<PlayerPanelScript> ().GetPlayerObject ();
	}
	
	// Update is called once per frame
	void Update () {
		currentBarWidth = maxBarWidth;
		//make sure current air is float!
		//currentBarWidth = (playerCurrentAir / maxBarWidth) * maxBarWidth
	}

	void OnGUI(){
		airRect = new Rect (posX, posY, currentBarWidth, Screen.height/50);
		GUI.DrawTexture (airRect, airTexture);
	}
}
