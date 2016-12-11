﻿using UnityEngine;
using System.Collections;

public class SneakyScript : MonoBehaviour {
	public SneakyScript sneak;

    // Use this for initialization
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;
    public int p1Rank;
    public int p2Rank;
    public int p3Rank;
    public int p4Rank;


	void Awake(){
		if (!sneak) {
			sneak = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (this);
		}
	}

    void Start () {

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player3 = GameObject.FindGameObjectWithTag("Player3");
        player4 = GameObject.FindGameObjectWithTag("Player4");
 
        if (player1 == null) {
           // player1.GetComponent<PlayerScript>().rank = -1;
            p1Rank = -1;
        }
        if (player2 == null) {
            //player2.GetComponent<PlayerScript>().rank = -1;
            p2Rank = -1;
        }
        if (player3 == null) {
           //player3.GetComponent<PlayerScript>().rank = -1;
            p3Rank = -1;
        }
        if (player4 == null) {
            //player4.GetComponent<PlayerScript>().rank = -1;
            p4Rank = -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
