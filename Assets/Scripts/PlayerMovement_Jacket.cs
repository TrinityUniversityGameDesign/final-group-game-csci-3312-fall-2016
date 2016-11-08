using UnityEngine;
using System.Collections;

public class PlayerMovement_Jacket : MonoBehaviour {

	public int playerNum;
	public float walkSpeed;
	public float dashSpeed;
	public float dashRegeneration;

	private Rigidbody2D rigid;
	private bool canDash = true;


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
		float dash = Input.GetAxis(jumpButton);
		if (canDash && dash > 0) {
			rigid.AddForce (new Vector2 (rigid.velocity.x * dash * dashSpeed, rigid.velocity.y * dash * dashSpeed));
			canDash = false;
			StartCoroutine (ResetDash ());
		}
	}

	IEnumerator ResetDash() {
		yield return new WaitForSeconds (dashRegeneration);
		canDash = true;
	}
		

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Water")) {
			Destroy (gameObject);
		}
	}
}
