using UnityEngine;
using System.Collections;

public class ScrollingWaterBackground : MonoBehaviour {

    public int waterMaterialCountdown;

    private Material waterMaterial;
    private int waterMaterialCountdownInner;
    private float y;

	// Use this for initialization
	void Start () {
        waterMaterialCountdownInner = waterMaterialCountdown;
        waterMaterial = GetComponent<MeshRenderer>().material;
        waterMaterial = GetComponent<Renderer>().material;
        y = 0.001f;
        //waterMaterial.SetTextureScale("_MainTex", new Vector2(transform.localScale.x / 10, transform.localScale.y / 10));
    }
	
	// Update is called once per frame
	void Update () {
        if (waterMaterialCountdownInner < 0)
        {
            y *= (-1);
            waterMaterialCountdownInner = waterMaterialCountdown;
        }
        else --waterMaterialCountdownInner;
        waterMaterial.SetTextureOffset("_MainTex", new Vector2(waterMaterial.mainTextureOffset.x + 0.004f, waterMaterial.mainTextureOffset.y+y));
    }
}
