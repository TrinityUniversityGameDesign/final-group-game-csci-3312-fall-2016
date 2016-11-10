using UnityEngine;
using System.Collections;

public class PlayerMovement_Jacket : MonoBehaviour {
	//Samuel's stuff
	private bool isDead = false;
	private int points = 0;
	private Vector3 dumpPosition = new Vector3(10000,10000,10000);
	private Vector3 spawnPosition;

	public int playerNum;
	public float walkSpeed;
	public float dashSpeed;
	public float dashRegeneration;

	private Rigidbody2D rigid;
	private bool canDash = true;


	private string vertAxis;
	private string horAxis;
	private string dashButton;

	// Use this for initialization
	void Start () {
		spawnPosition = transform.position;
		rigid = GetComponent<Rigidbody2D> ();
		vertAxis = "Vertical_P" + playerNum.ToString();
		horAxis = "Horizontal_P" + playerNum.ToString();
		dashButton = "A_P" + playerNum.ToString();

	}
	
	// Update is called once per frame
	void Update () {

		rigid.velocity = new Vector2 (Input.GetAxis (horAxis) * walkSpeed, Input.GetAxis (vertAxis) * walkSpeed);

		//TODO : Add dashing in
		float dash = Input.GetAxis(dashButton);
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
			OnDeath ();
		}
	}


	//Samuel's Functions;
	void OnDeath() {
		//Destroy (gameObject);
		isDead = true;
		Debug.Log("I died!");
		transform.position = dumpPosition;
	}
	public void Respawn(){
		//teleport player back to start
		isDead = false;
		transform.position = spawnPosition;
	}
	public void AddPoint(){
		points++;
	}
	public int GetPoints(){
		return points;
	}
	public void SetDead(bool d){
		isDead = d;
	}
	public bool IsDead(){
		return isDead;
	}
}
