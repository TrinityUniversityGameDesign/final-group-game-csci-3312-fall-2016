using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryDisplay : MonoBehaviour {

    public Text RandomInputText;
    int x = 0;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        
        RandomInputText.text = x.ToString();
        timeToDisplay();
	}

    void timeToDisplay()
    {
        x += 1;
    }
}
