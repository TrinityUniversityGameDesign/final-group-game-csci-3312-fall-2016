using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class keyGeneration : MonoBehaviour {
    private Vector3[] keyLocs;
	private Vector3[] portalLocs;
    private GameObject key;
	private GameObject portal;
    private ArrayList keys;
    public int keyNum = 6;

    // Use this for initialization
    void Start()
    {
        keyLocs = new[] { new Vector3(-.67f, 5.39f, 0f),
                          new Vector3(-8f, 2.5f, 0f),
                          new Vector3(0.5f, 2.45f, 0f),
                          new Vector3(12.6f, 6f, 0f),
                          new Vector3(17f, 6f, 0f),
                          new Vector3(17f, -3.15f, 0f),
                          new Vector3(7.4f, -6.9f, 0f),
                          new Vector3(2f, -2.3f, 0f)
       };
		portalLocs = new [] { new Vector3 (16, 6, 1) };
		portal = Resources.Load<GameObject>("darkroom_Assets/Resources/Prefabs/Portal");
        key = Resources.Load<GameObject>("darkroom_Assets/Resources/Prefabs/key");
        HashSet<int> keypool = new HashSet<int>();
        keys = new ArrayList();
        int rover = keyNum;
        while (rover > 0)
        {
            bool success = false;
            while (!success)
            {
                int pos = (int)Random.Range(0, keyLocs.Length);
                success = keypool.Add(pos);
            }
            --rover;
        }
        Debug.Log(keypool.Count);
        foreach (int i in keypool)
        {
            GameObject newkey = (GameObject)Instantiate(key, keyLocs[i], Quaternion.identity);
            newkey.transform.parent = gameObject.transform;
            newkey.transform.localPosition = keyLocs[i];
            keys.Add(newkey);
        }
		GameObject portalInit = (GameObject)Instantiate(portal, portalLocs[0], Quaternion.identity);
		portalInit.transform.parent = gameObject.transform;
		portalInit.transform.localPosition = portalLocs[0];

    }

	 
    // Update is called once per frame
    void Update()
    {

    }
}
