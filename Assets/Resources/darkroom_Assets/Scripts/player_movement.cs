using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
	public float speed = .05f;
    public int controller;
	private Rigidbody2D rigid_body;
	public GameObject player;
	Vector3 player_pos;



	// Use this for initialization
	void Start () {        
		rigid_body = GetComponent<Rigidbody2D>();		
		player_pos = player.transform.position;  
		if (this.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			this.gameObject.transform.position = new Vector3 (1, 38, 0);
		}
        

	}

	// Update is called once per frame
	void Update () {

		float translation_X = Input.GetAxis ("Horizontal" + controller) * speed;
		float translation_Y = Input.GetAxis ("Vertical" + controller) * speed;
        rigid_body.velocity = new Vector2(translation_X, translation_Y);
		//rigid_body.transform.position = new Vector3 (player_pos.x + translation_X, player_pos.y + translation_Y, player_pos.z);
		player_pos = player.transform.position;

		if (this.gameObject.GetComponentInChildren<Light> ().range < 3) {
			Application.LoadLevel (1);
		}

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("!!!!!");
    }

}