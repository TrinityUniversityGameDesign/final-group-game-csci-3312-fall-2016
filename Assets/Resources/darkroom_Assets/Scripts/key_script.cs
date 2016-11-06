using UnityEngine;
using System.Collections;

public class key_script : MonoBehaviour {
	bool player_has_key = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
			Debug.Log("Player on top of key");
			player_has_key = true;
			this.gameObject.SetActive (false);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
			Debug.Log("Player has left the key location");
			player_has_key = false;
		}
	}

}
