using UnityEngine;
using System.Collections;

public class door_script : MonoBehaviour {
    public GameObject player;
    public int numPlayers;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    void Start()
    {
        player = this.transform.parent.GetComponent<door>().player;
        enemy1 = this.transform.parent.GetComponent<door>().enemy1;
        enemy2 = this.transform.parent.GetComponent<door>().enemy2;
        enemy3 = this.transform.parent.GetComponent<door>().enemy3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player || other.gameObject == enemy1 || other.gameObject == enemy2 || other.gameObject == enemy3)
        {
            if (this.transform.parent.GetComponent<door>().locked == false)
            {
                this.transform.parent.GetComponent<door>().opening = true;
            }
        }
        else
        {
            this.transform.parent.GetComponent<door>().closing = true;
        }
    }
}
