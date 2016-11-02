using UnityEngine;
using System.Collections;

public class rb_movement : MonoBehaviour {

	private Rigidbody2D rb;
	public GameObject player;
	public float speed = .05f;
	Vector3 player_pos;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		player_pos = player.transform.position;  


	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, player_pos.z);
		rb.AddForce (movement * speed);
	}
}
