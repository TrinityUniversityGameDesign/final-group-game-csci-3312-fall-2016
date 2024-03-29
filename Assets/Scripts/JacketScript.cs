﻿using UnityEngine;
using System.Collections;

public class JacketScript : MonoBehaviour
{
    public string inflateBtnL;
    public string inflateBtnR;
    public string explodeBtn;
	
    public float jacketScale;
    //1.5f possible default
    public float startJacketScale;

    //6.0f possible default
    public float maxJacketSize;

    private Transform theTransform;
    private Rigidbody2D theRigibody;

	public AudioClip explosionClip;
	public AudioClip pumpClip;
	AudioSource audioSource;

	bool canInflate;
    private bool lNext;

	bool isDeflating;

    public GlobalPlayerControllerScript gameCont;
    void Awake() { gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>(); }

    // Use this for initialization
    void Start()
    {
		canInflate = true;
		isDeflating = false;
        theTransform = gameObject.GetComponent<Transform>();
        theRigibody = gameObject.GetComponentInParent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(gameCont.players[transform.parent.gameObject.GetComponent<PlayerMovement_Jacket>().playerNum].LB))
        //if(Input.GetKeyDown("r"))
        {
            if (lNext)
            {
                Inflate();
                lNext = false;
            }
        } if (Input.GetButtonDown(gameCont.players[transform.parent.gameObject.GetComponent<PlayerMovement_Jacket>().playerNum].RB)) {
            //else if (Input.Input("l"))
            {
                if (!lNext)
                {
                    Inflate();
                    lNext = true;
                }
            }
        }
        if (Input.GetButtonDown(gameCont.players[transform.parent.gameObject.GetComponent<PlayerMovement_Jacket>().playerNum].ABut))
        {
			Debug.Log(jacketScale);
			if (jacketScale > 1) {
				Explode ();
			}
        }
		if (jacketScale > startJacketScale) {
			ConstantDeflate ();
		} else {
			isDeflating = false;
		}
		if (isDeflating) {
			theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
		}
        
    }

    public void SuckAllDaAirOut()
    {
        jacketScale = startJacketScale;


    }

    void ConstantDeflate()
    {
        if(jacketScale > startJacketScale) { jacketScale -= (Time.deltaTime); }
    }

    void Inflate()
    {
		if (!isDeflating && canInflate) {
			if (jacketScale < maxJacketSize) {
				jacketScale += .6f * ((maxJacketSize - jacketScale) / maxJacketSize);
			}
			audioSource.clip = pumpClip;
			audioSource.Play ();
		}
    }

    void Explode()
    {
        gameObject.transform.parent.GetComponent<Rigidbody2D>().mass = 10000f;
        while(theTransform.localScale.x < jacketScale)
        {
            theTransform.localScale = new Vector3((theTransform.localScale.x+.001f) , (theTransform.localScale.y+ .001f), 1f);
        }
		theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
        StartCoroutine(Deflate(.5f));
        //Debug.Log("exploded");
		audioSource.clip = explosionClip;
		audioSource.Play ();

    }

    IEnumerator Deflate(float secs)
    {
		canInflate = false;
        yield return new WaitForSeconds(secs);
		canInflate = true;
		isDeflating = true;
        //jacketScale = startJacketScale;
		//theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
        theRigibody.mass = 1f;
        //Debug.Log("deflated");
    }

	public void ResetJacket(){
		theTransform.localScale = new Vector3(startJacketScale, startJacketScale, 1f);
		isDeflating = false;
	}

}
