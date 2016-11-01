using UnityEngine;
using System.Collections;

public class edgeTilerScript : MonoBehaviour {
    public GameObject tile;
	// Use this for initialization
	void Start () {
        float x = tile.GetComponent<SpriteRenderer>().bounds.size.x;
        float y = tile.GetComponent<SpriteRenderer>().bounds.size.y;
        float pixWidth = Screen.width*2 - (200 * x);
        float xRemainder = pixWidth % (100 * x);
        int numXWidth = (int)(pixWidth / (100 * x));
        Debug.Log(pixWidth);
        Debug.Log(numXWidth);
        for(float i = -numXWidth/2; i <= numXWidth/2; i++)
        {
            Instantiate(tile, new Vector2(i, (Camera.main.ScreenToWorldPoint(new Vector2(0, 0))).y + 0.5f*x), Quaternion.identity);
            Instantiate(tile, new Vector2(i, (Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))).y - 0.5f * x), Quaternion.identity);
        }

        float pixHeight = Screen.height * 2 - (200 * y);
        float yRemainder = pixHeight % (100 * y);
        int numYHeight = (int)(pixHeight / (100 * y));
        for (float i = -numYHeight / 2; i <= numYHeight / 2; i++)
        {
            Instantiate(tile, new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(0, 0))).x + 0.5f * y, i), Quaternion.identity);
            Instantiate(tile, new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))).x - 0.5f * y, i), Quaternion.identity);
        }
        Debug.Log(x);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
