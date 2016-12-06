using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {

    public int portalNum;
    private Vector3[] portalLocs;

    // Use this for initialization
    void Start () {
        portalLocs = new[] { new Vector3(21f,36.5f,0f),
                            new Vector3(13.7f, -1f, 0),
                            new Vector3(28.8f, -1f, 0),
                            new Vector3(-1.6f, 20f, 0),
                            new Vector3(40f, 20f, 0)};
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if(portalNum == 0)
            {
                other.gameObject.transform.position = portalLocs[Mathf.RoundToInt(1 + Random.value)];
            } else if(portalNum == 1 || portalNum == 2)
            {
                other.gameObject.transform.position = portalLocs[0];
            } else if(portalNum == 3){
                other.gameObject.transform.position = portalLocs[4];
            } else if(portalNum == 4)
            {
                other.gameObject.transform.position = portalLocs[3];
            }
        }
    }
}
