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
        keyLocs = new[] { new Vector3(.4f, 30f, 0f),
                          new Vector3(8f, 31f, 0f),
                          new Vector3(18f, 31f, 0f),
                          new Vector3(18f, 26f, 0f),
                          new Vector3(12f, 26f, 0f),
                          new Vector3(.5f, 26f, 0f),
                          new Vector3(28f, 27f, 0f),
                          new Vector3(27f, 34.5f, 0f),
                          new Vector3(35f, 34.5f, 0f),
                          new Vector3(35f, 21.6f, 0f),
                          new Vector3(33.7f, 15.7f, 0f),
                          new Vector3(36.2f, 8.2f, 0f),
                          new Vector3(31.5f, 8.2f, 0f),
                          new Vector3(27.5f, 10.5f, 0f),
                          new Vector3(17.2f, 10.5f, 0f),
                          new Vector3(24.4f, 16.3f, 0f),
                          new Vector3(17f, 16.3f, 0f),
                          new Vector3(1.7f, 16.3f, 0f),
                          new Vector3(2.7f, 10f, 0f),
                          new Vector3(2.7f, 2.4f, 0f),
                          new Vector3(9.5f, 2.4f, 0f),
                          new Vector3(17.3f, 2.4f, 0f),
                          new Vector3(24f, 2.4f, 0f),
                          new Vector3(32.3f, 1.5f, 0f),
                          new Vector3(37f, 4f, 0f)
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
		/*GameObject portalInit = (GameObject)Instantiate(portal, portalLocs[0], Quaternion.identity);
		portalInit.transform.parent = gameObject.transform;
		portalInit.transform.localPosition = portalLocs[0];*/

    }

	 
    // Update is called once per frame
    void Update()
    {

    }
}
