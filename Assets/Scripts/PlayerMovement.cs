using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int playerNum;
	public float walkSpeed;

	private Rigidbody2D rigid;
	private bool canDash;


	private string vertAxis;
	private string horAxis;
	private string jumpButton;
	private string actionButton;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		vertAxis = "VerticalP" + playerNum.ToString();
		horAxis = "HorizontalP" + playerNum.ToString();
		jumpButton = "JumpP" + playerNum.ToString();
		actionButton = "ActionP" + playerNum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		rigid.velocity = new Vector2 (Input.GetAxis (horAxis) * walkSpeed, Input.GetAxis (vertAxis) * walkSpeed);
		//TODO : Add dashing in
	}
}
