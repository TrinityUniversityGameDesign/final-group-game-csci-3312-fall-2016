using UnityEngine;
using System.Collections;

public class JacketScript : MonoBehaviour
{
    public string inflateBtn;
    public string explodeBtn;
	
    public float jacketScale;
    //1.5f possible default
    public float startJacketScale;

    //6.0f possible default
    public float maxJacketSize;

    private Transform theTransform;
    private Rigidbody2D theRigibody;

    // Use this for initialization
    void Start()
    {
        theTransform = gameObject.GetComponent<Transform>();
        theRigibody = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(inflateBtn))
        {
            Inflate();
        }
        if (Input.GetButtonDown(explodeBtn))
        {
            Explode();
        }
        if (jacketScale > startJacketScale) {
            ConstantDeflate();
        }
        
    }

    void ConstantDeflate()
    {/*
        if (jacketScale < maxJacketSize / 2.0f)
        {
            if((jacketScale - (Time.deltaTime / 2f)) >= startJacketScale)
                jacketScale -= (Time.deltaTime/2f);
            else
                jacketScale = startJacketScale;
        }
        else
        {
            if ((jacketScale - (Time.deltaTime / 4f)) >= startJacketScale)
                jacketScale -= (Time.deltaTime / 4f);
            else
                jacketScale = startJacketScale;
        }
        */
        if(jacketScale > startJacketScale) { jacketScale -= (Time.deltaTime); }
        Debug.Log(jacketScale);
    }

    void Inflate()
    {
        if (jacketScale < maxJacketSize) { jacketScale += .8f * ((maxJacketSize - jacketScale)/maxJacketSize); }
        Debug.Log(jacketScale);
    }

    void Explode()
    {
        gameObject.transform.parent.GetComponent<Rigidbody2D>().mass = 10000f;
        while(theTransform.localScale.x < jacketScale)
        {
            theTransform.localScale = new Vector3((theTransform.localScale.x+Time.deltaTime) , (theTransform.localScale.y+ Time.deltaTime), 1f);
        }
		theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
        StartCoroutine(Deflate(.5f));
        Debug.Log("exploded");
    }

    IEnumerator Deflate(float secs)
    {
        yield return new WaitForSeconds(secs);
        jacketScale = startJacketScale;
		theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
        theRigibody.mass = 1f;
        Debug.Log("deflated");
    }

}
