using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public bool opening;
    public bool closing;
    public bool locked;
    public GameObject door;
    public GameObject player;
    public int numPlayers;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float slideDistance;
    public float slideSpeed;

	// Use this for initialization
	void Start () {
        this.locked = false;
        this.opening = false;
        this.closing = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if(opening)
        {
            if(door.transform.localPosition.x < slideDistance)
            {
                door.transform.localPosition = new Vector3(door.transform.localPosition.x+Time.deltaTime* slideSpeed, door.transform.localPosition.y, door.transform.localPosition.z);
            }
            else
            {
                opening = false;
            }
        }
        if(closing)
        {
            if(door.transform.localPosition.x > 0)
            {
                door.transform.localPosition = new Vector3(door.transform.localPosition.x - Time.deltaTime * slideSpeed, door.transform.localPosition.y, door.transform.localPosition.z);
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
        if(other.gameObject == player || other.gameObject == enemy1 || other.gameObject == enemy2 || other.gameObject == enemy3)
        {
            if(locked == false)
            {
                opening = true;
            }
        }
        else
        {
            closing = true;
        }
    }
}
