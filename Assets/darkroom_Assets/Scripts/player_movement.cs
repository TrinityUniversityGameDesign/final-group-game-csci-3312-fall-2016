using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
	public float speed = .05f;
	private Rigidbody2D rigid_body;
	GameObject player;
	Vector3 player_pos;



	// Use this for initialization
	void Start () {
		rigid_body = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("green_square");
		Vector3 player_pos = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		float translation_X = Input.GetAxis ("Horizontal") * speed;
		float translation_Y = Input.GetAxis ("Vertical") * speed;
		rigid_body.transform.position = new Vector2 (player_pos.x + translation_X, player_pos.y + translation_Y);
		player_pos = player.transform.position;

	}
}
