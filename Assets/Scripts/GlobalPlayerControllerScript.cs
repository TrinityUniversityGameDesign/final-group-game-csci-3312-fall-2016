using UnityEngine;
using System.Collections;

public class PlayerInput {
	private string p_playerNum;
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

	public PlayerInput(string pNum){
		p_playerNum = pNum;
		p_hor = "Horizontal_" + p_playerNum;
		p_vert = "Vertical_" + p_playerNum;
		p_ABut = "A_" + p_playerNum;
		p_BBut  = "B_" + p_playerNum;
		p_YBut = "Y_" + p_playerNum;
		p_XBut  = "X_" + p_playerNum;
		p_startBut = "Start_" + p_playerNum;
		p_backBut  = "Back_" + p_playerNum;
		p_L3 = "L3_" + p_playerNum; 
		p_R3 = "R3_" + p_playerNum;  
		p_LB = "LB_" + p_playerNum; 
		p_RB = "RB_" + p_playerNum; 
		p_LT = "LT_" + p_playerNum; 
		p_RT  = "RT_" + p_playerNum; 
		p_rightX = "RightX_" + p_playerNum;
		p_rightY  = "RightY_" + p_playerNum;
		p_DPadX = "DPadX_" + p_playerNum;
		p_DPadY = "DPadY_" + p_playerNum;
	}
	public string hor{
		get { return p_hor; }
	}
	public string vert{
		get { return p_vert; }
	}
	public string ABut{
		get { return p_ABut; }
	}
	public string BBut{
		get { return p_BBut; }
	}
	public string YBut{
		get { return p_YBut; }
	}
	public string XBut{
		get { return p_XBut; }
	}
	public string startBut{
		get { return p_startBut; }
	}
	public string backBut{
		get { return p_backBut; }
	}
	public string L3{
		get { return p_L3; }
	}
	public string R3{
		get { return p_R3; }
	}
	public string LB{
		get { return p_LB; }
	}
	public string RB{
		get { return p_RB; }
	}
	public string LT{
		get { return p_LT; }
	}
	public string RT{
		get { return p_RT; }
	}
	public string rightX{
		get { return p_rightX; }
	}
	public string rightY{
		get { return p_rightY; }
	}
	public string DPadX{
		get { return p_DPadX; }
	}
	public string DPadY{
		get { return p_DPadY; }
	}
}

public class GlobalPlayerControllerScript : MonoBehaviour {
	public static GlobalPlayerControllerScript gameCont;

	public int num_players;

	public PlayerInput player1_in;
	public PlayerInput player2_in;
	public PlayerInput player3_in;
	public PlayerInput player4_in;

	void Awake(){
		if (!gameCont) {
			gameCont = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


