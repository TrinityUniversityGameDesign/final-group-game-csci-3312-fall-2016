using UnityEngine;
using System.Collections;

public class door_script : MonoBehaviour {
    private GameObject player;
    private int numPlayers;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;

    public LayerMask PlayerLayer;
    public LayerMask EnemyLayer;

    void Start()
    {
        player = this.transform.parent.gameObject.GetComponent<doorComboScript>().player;
        enemy1 = this.transform.parent.gameObject.GetComponent<doorComboScript>().enemy1;
        enemy2 = this.transform.parent.gameObject.GetComponent<doorComboScript>().enemy2;
        enemy3 = this.transform.parent.gameObject.GetComponent<doorComboScript>().enemy3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("in!");
            if (this.transform.parent.GetComponent<doorComboScript>().locked == false)
            {
                
                this.transform.parent.GetComponent<doorComboScript>().opening = true;
            }
        }
        else
        {
            this.transform.parent.GetComponent<doorComboScript>().closing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("out!");
            this.transform.parent.GetComponent<doorComboScript>().closing = true;

        }
    }
}
