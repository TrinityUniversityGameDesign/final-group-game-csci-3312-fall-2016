using UnityEngine;
using System.Collections;

public class JacketScript : MonoBehaviour
{
    public string inflateBtn;
    public string explodeBtn;

    public float jacketScale = 1.5f;
    public float maxJacketSize = 6.0f;

    private Transform theTransform;

    // Use this for initialization
    void Start()
    {
        theTransform = gameObject.GetComponent<Transform>();
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
            jacketScale += 0.5f;
        }
        Debug.Log(jacketScale);
    }

    void Explode()
    {
        theTransform.localScale = new Vector3(jacketScale, jacketScale, 1f);
        StartCoroutine(Deflate(0.5f));
        Debug.Log("exploded");
    }

    IEnumerator Deflate(float secs)
    {
        yield return new WaitForSeconds(secs);
        theTransform.localScale = new Vector3(1.5f, 1.5f, 1f);
        Debug.Log("deflated");
    }

}
