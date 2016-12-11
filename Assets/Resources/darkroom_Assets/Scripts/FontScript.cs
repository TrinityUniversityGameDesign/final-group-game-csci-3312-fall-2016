using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FontScript : MonoBehaviour {

    // Use this for initialization
    
    public GameObject[] texts;
    string font = PlayerPrefs.GetString("font_name");
    void Start () {
       
        //SetFont(font);
	}
    void SetFont(string f)
    {
        foreach(GameObject x in texts)
        {
            x.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>(f + ".ttf");
        }
        
       
    }
    // Update is called once per frame
    void Update () {
	
	}
}
