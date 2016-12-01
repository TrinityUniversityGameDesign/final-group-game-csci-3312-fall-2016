using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleContinueScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Start_P1"))
        {
            SceneManager.LoadScene(1);
        }
	
	}
}
