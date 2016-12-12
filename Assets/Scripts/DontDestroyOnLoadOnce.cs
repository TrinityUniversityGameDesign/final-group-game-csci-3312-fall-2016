using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadOnce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
