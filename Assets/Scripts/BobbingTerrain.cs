using UnityEngine;
using System.Collections;

public class BobbingTerrain : MonoBehaviour {

    public GameObject waterQuad;

    private float y;

	// Use this for initialization
	void Start () {
        y = waterQuad.GetComponent<Renderer>().material.mainTextureOffset.y;
    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.position.y = y;
	}
}
