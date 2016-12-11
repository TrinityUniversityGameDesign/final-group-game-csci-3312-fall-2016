using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeColor : MonoBehaviour {
    Color newCol;
    public int playerNumber;
    public Image uniform;
	// Use this for initialization
	void Start () {
        string playerName = "player" + playerNumber + "_color";
        string htmlValue = PlayerPrefs.GetString(playerName);
        if (ColorUtility.TryParseHtmlString(htmlValue, out newCol))
            uniform.color = newCol;
    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
