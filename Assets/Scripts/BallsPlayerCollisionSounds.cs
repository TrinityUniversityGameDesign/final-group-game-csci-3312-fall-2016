using UnityEngine;
using System.Collections;

public class BallsPlayerCollisionSounds : MonoBehaviour {

    public AudioSource aSource;

    public AudioClip boing1;
    public AudioClip boing2;
    public AudioClip boing3;
    public AudioClip boing4;
    public AudioClip boing5;
    public AudioClip boing6;
    public AudioClip boing7;
    public AudioClip boing8;
    public AudioClip boing9;
    public AudioClip boing10;
    public AudioClip boing11;
    public AudioClip boing12;
    public AudioClip boing13;
    public AudioClip[] boingList;
    public AudioClip fall1;

	// Use this for initialization
	void Start () {
        aSource = this.GetComponent<AudioSource>();
        boingList = new AudioClip[] { boing1, boing2, boing3, boing4, boing5, boing6, boing7, boing8, boing9, boing10, boing11, boing12, boing13 };
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        int randStage = (int)(Random.value * 13);
        
        
        aSource.PlayOneShot(boingList[randStage], 1f);
        print("Audio Played!");
    }
}
