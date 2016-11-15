using UnityEngine;
using System.Collections;

public class BobbingTerrain : MonoBehaviour {

    public GameObject waterQuad;

    private Material waterQuadMaterial;
    private float prevY;

	// Use this for initialization
	void Start () {
        //prevY = 0f;
        waterQuadMaterial = waterQuad.GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += new Vector3(0, waterQuad.GetComponent<ScrollingWaterBackground>().GetY(), 0);
	}
}
