using UnityEngine;
using System.Collections;

public class dim_light : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
			Debug.Log("Enemy/Player collision");
			other.gameObject.GetComponentInChildren<Light> ().range -= 1;
			this.transform.position = new Vector3 (1, 36, 0);
		}
	}
}
