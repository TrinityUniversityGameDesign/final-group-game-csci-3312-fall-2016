using UnityEngine;
using System.Collections;

public class JacketScript : MonoBehaviour
{
    public string inflateBtn;
    public string explodeBtn;

	//1.5f default
    public float jacketScale;
    public float startJacketScale;

	//6.0f default
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
    {
           // StartCoroutine(Delay(1.5f));
        if (jacketScale < maxJacketSize / 2.0f)
        {
            if((jacketScale - (Time.deltaTime / 2)) >= startJacketScale)
                jacketScale -= (Time.deltaTime/2);
            else
                jacketScale = startJacketScale;
        }
        else
        {
            if ((jacketScale - (Time.deltaTime / 4)) >= startJacketScale)
                jacketScale -= (Time.deltaTime / 4);
            else
                jacketScale = startJacketScale;
        }
        
        Debug.Log(jacketScale);
    }

    IEnumerator Delay(float secs) {
        yield return new WaitForSeconds(secs);
    }

    void Inflate()
    {
        if (jacketScale < maxJacketSize)
        {
            if (jacketScale < maxJacketSize / 2.0f)
            {
                jacketScale += 0.5f;
            }
            else {
                jacketScale += 0.25f;
            }
        }
        Debug.Log(jacketScale);
    }

    void Explode()
    {
        theRigibody.mass = 10000f;
		theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
        StartCoroutine(Deflate(0.5f));
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
