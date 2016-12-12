using UnityEngine;
using System.Collections;

public class dim_light : MonoBehaviour {
	Vector3 old_pos;
    AudioSource torchPutOut;
	// Use this for initialization
	void Start () {
		old_pos = this.transform.position;
        torchPutOut = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy_Player")){
			Debug.Log("Enemy/Player collision");

            torchPutOut.Play();

			other.gameObject.transform.parent.GetComponentInChildren<Light> ().range -= 1;
			this.transform.position = old_pos;
		}
	}
}
