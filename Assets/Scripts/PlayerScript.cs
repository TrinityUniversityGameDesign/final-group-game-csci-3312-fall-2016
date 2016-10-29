using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInput {
	private string p_hor;
	private string p_vert;
	private string p_ABut;
	private string p_BBut;
	private string p_YBut;
	private string p_XBut;
	private string p_startBut;
	private string p_backBut;
	private string p_L3; 
	private string p_R3; 
	private string p_LB; 
	private string p_RB; 
	private string p_LT; 
	private string p_RT; 
	private string p_rightX;
	private string p_rightY;
	private string p_DPadX;
	private string p_DPadY;

	public string hor{
		get { return p_hor; }
		set { p_hor = value; }
	}
	public string vert{
		get { return p_vert; }
		set { p_vert = value; }
	}
	public string ABut{
		get { return p_ABut; }
		set { p_ABut = value; }
	}
	public string BBut{
		get { return p_BBut; }
		set { p_BBut = value; }
	}
	public string YBut{
		get { return p_YBut; }
		set { p_YBut = value; }
	}
	public string XBut{
		get { return p_XBut; }
		set { p_XBut = value; }
	}
	public string startBut{
		get { return p_startBut; }
		set { p_startBut = value; }
	}
	public string backBut{
		get { return p_backBut; }
		set { p_backBut = value; }
	}
	public string L3{
		get { return p_L3; }
		set { p_L3 = value; }
	}
	public string R3{
		get { return p_R3; }
		set { p_R3 = value; }
	}
	public string LB{
		get { return p_LB; }
		set { p_LB = value; }
	}
	public string RB{
		get { return p_RB; }
		set { p_RB = value; }
	}
	public string LT{
		get { return p_LT; }
		set { p_LT = value; }
	}
	public string RT{
		get { return p_RT; }
		set { p_RT = value; }
	}
	public string rightX{
		get { return p_rightX; }
		set { p_rightX = value; }
	}
	public string rightY{
		get { return p_rightY; }
		set { p_rightY = value; }
	}
	public string DPadX{
		get { return p_DPadX; }
		set { p_DPadX = value; }
	}
	public string DPadY{
		get { return p_DPadY; }
		set { p_DPadY = value; }
	}
}

public class PlayerScript : MonoBehaviour {
	public string playerNum;
	public PlayerInput iC;

	public GameObject memDisp; 



	public List<Buttons> InputList;
	// Use this for initialization

	void Awake(){
		iC = new PlayerInput ();
		InputList = new List<Buttons> ();
	}

	void Start () {
		memDisp = GameObject.Find ("MemoryDisplay");
		playerNum = "P1"; // should change on instantiation
		iC.hor = "Horizontal_" + playerNum;
		iC.vert = "Vertical_" + playerNum;
		iC.ABut = "A_" + playerNum;
		iC.BBut = "B_" + playerNum;
		iC.YBut = "Y_" + playerNum;
		iC.XBut = "X_" + playerNum;
		iC.startBut = "Start_" + playerNum;
		iC.backBut = "Back_" + playerNum;
		iC.L3 = "L3_" + playerNum; 
		iC.R3 = "R3_" + playerNum; 
		iC.LB = "LB_" + playerNum; 
		iC.RB = "RB_" + playerNum; 
		iC.LT = "LT_" + playerNum; 
		iC.RT = "RT_" + playerNum; 
		iC.rightX = "RightX_" + playerNum;
		iC.rightY = "RightY_" + playerNum;
		iC.DPadX = "DPadX_" + playerNum; 
		iC.DPadY = "DPadY_" + playerNum;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown (iC.ABut)) {
			InputList.Add (Buttons.A);
		}
		if (Input.GetButtonDown (iC.BBut)) {
			InputList.Add (Buttons.B);
		}
		if (Input.GetButtonDown (iC.YBut)) {
			InputList.Add (Buttons.Y);
		}
		if (Input.GetButtonDown (iC.XBut)) {
			InputList.Add (Buttons.X);
		}


	}
}
