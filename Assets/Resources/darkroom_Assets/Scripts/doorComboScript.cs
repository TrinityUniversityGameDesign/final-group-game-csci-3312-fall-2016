using UnityEngine;
using System.Collections;

public class doorComboScript : MonoBehaviour {
    private bool opening;
    private bool closing;
    public bool locked;
    public GameObject dr;
    public GameObject player;
    public int numPlayers;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float slideDistance;
    public float slideSpeed;
    private AudioSource[] sounds;
    private AudioSource doorLockSound;
    private AudioSource doorOpenSound;
    // Use this for initialization
    void Start()
    {
        this.locked = false;
        this.opening = false;
        this.closing = true;
        sounds = GetComponents<AudioSource>();
        doorLockSound = sounds[0];
        doorOpenSound = sounds[1];

        
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
            doorOpenSound.Play();
        }
        else
        {
            locked = true;
            closing = true;
            doorLockSound.Play();
        }
    }

    public void OpenDoor()
    {
        if (!locked)
        {
            opening = true;
            doorOpenSound.Play();
        }
    }

    public void CloseDoor()
    {
        closing = true;
        doorLockSound.Play();
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
