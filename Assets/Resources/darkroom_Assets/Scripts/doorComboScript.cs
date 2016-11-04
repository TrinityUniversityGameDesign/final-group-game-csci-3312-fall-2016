using UnityEngine;
using System.Collections;

public class doorComboScript : MonoBehaviour {
    public bool opening;
    public bool closing;
    public bool locked;
    public GameObject dr;
    public GameObject player;
    public int numPlayers;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float slideDistance;
    public float slideSpeed;
    // Use this for initialization
    void Start()
    {
        this.locked = false;
        this.opening = false;
        this.closing = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            if (dr.transform.localPosition.x < slideDistance)
            {
                dr.transform.localPosition = new Vector3(dr.transform.localPosition.x + Time.deltaTime * slideSpeed, dr.transform.localPosition.y, dr.transform.localPosition.z);
                Debug.Log("x: " + dr.transform.localPosition.x);
            }
            else
            {
                opening = false;
            }
        }
        if (closing)
        {
            if (dr.transform.localPosition.x > 0)
            {
                dr.transform.localPosition = new Vector3(dr.transform.localPosition.x - Time.deltaTime * slideSpeed, dr.transform.localPosition.y, dr.transform.localPosition.z);
                Debug.Log("x: " + dr.transform.localPosition.x);
            }
            else
            {
                closing = false;
            }
        }
    }

    public void LockDoor()
    {
        locked = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("in!");
            if (locked == false)
            {

                opening = true;
            }
        }
        else
        {
            closing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("out!"); 
            closing = true;

        }
    }
}
