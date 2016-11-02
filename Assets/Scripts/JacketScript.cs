using UnityEngine;
using System.Collections;

public class JacketScript : MonoBehaviour
{
    public string inflateBtn;
    public string explodeBtn;

    public float jacketScale = 1.5f;
    public const float startJacketScale = 1.5f;
    public float maxJacketSize = 6.0f;

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
