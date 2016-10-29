using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerScript : MonoBehaviour {

	public string hor;
	public string vert;
	public string ABut;
	public string BBut;
	public string YBut;
	public string XBut;
	public string startBut;
	public string backBut;
	public string L3; 
	public string R3; 
	public string LB; 
	public string RB; 
	public string LT; 
	public string RT; 
	public string rightX;
	public string rightY;
	public string DPadX;
	public string DPadY;
	public int playerNum;



	public enum Buttons {A,B,X,Y};
	List<Buttons> InputList;
	// Use this for initialization
	void Start () {
		playerNum = 1; // should change on instantiation 
		hor = "Horizontal_" + playerNum;
		vert = "Vertical_" + playerNum;
		ABut = "A_" + playerNum;
		BBut = "B_" + playerNum;
		YBut = "Y_" + playerNum;
		XBut = "X_" + playerNum;
		startBut = "Start_" + playerNum;
		backBut = "Back_" + playerNum;
		L3 = "L3_" + playerNum; 
		R3 = "R3_" + playerNum; 
		LB = "LB_" + playerNum; 
		RB = "RB_" + playerNum; 
		LT = "LT_" + playerNum; 
		RT = "RT_" + playerNum; 
		rightX = "RightX_" + playerNum;
		rightY = "RightY_" + playerNum;
		DPadX = "DPadX_" + playerNum; 
		DPadY = "DPadY_" + playerNum;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
