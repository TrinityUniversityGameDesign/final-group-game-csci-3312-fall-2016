using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
    private Text winText;
    private Text timer;

    public float time = 60f;

    public static int alivePlayers = 2;

	// Use this for initialization
	void Start () {
        winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.gameObject.SetActive(false);
        timer = GameObject.Find("Timer").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (alivePlayers == 1)
        {
            winText.gameObject.SetActive(true);
            string winPlayer = GameObject.FindGameObjectWithTag("Player").name;
            winText.text = winPlayer + " wins!";
        }
        else if(time <= 0)
        {
            winText.gameObject.SetActive(true);
            timer.text = "0";
            winText.text = "Game Over";
        }
        else
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("n0");
        }
	}
}
