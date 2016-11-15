using UnityEngine;
using System.Collections;

public class doorComboScript : MonoBehaviour {
    private bool opening;
    private bool closing;
    private bool locked;
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
            }
            else
            {
                opening = false;
            }
        }
        else if (closing)
        {
            if (dr.transform.localPosition.x > 0)
            {
                dr.transform.localPosition = new Vector3(dr.transform.localPosition.x - Time.deltaTime * slideSpeed, dr.transform.localPosition.y, dr.transform.localPosition.z);
            }
            else
            {
                closing = false;
            }
        }
    }

    public void LockDoor()
    {
        if (locked)
        {
            locked = false;
            opening = true;
        }
        else
        {
            locked = true;
            closing = true;
        }
    }

    public void OpenDoor()
    {
        if (!locked)
        {
            opening = true;
        }
    }

    public void CloseDoor()
    {
        closing = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if ( other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            OpenDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            CloseDoor();

        }
    }
}
