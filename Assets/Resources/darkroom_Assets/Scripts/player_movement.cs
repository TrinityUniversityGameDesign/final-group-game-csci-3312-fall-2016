using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {
	public float speed = .05f;
    public int controller;
	private Rigidbody2D rigid_body;
	public GameObject player;
	Vector3 player_pos;
	Text keyScore;
    public int keyOwn = 0;
    private ArrayList toBeLockedDoors;


	// Use this for initialization
	void Start () {        
		rigid_body = GetComponent<Rigidbody2D>();		
		player_pos = player.transform.position;  
		if (this.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			//this.gameObject.transform.position = new Vector3 (1, 38, 0);
		}
        toBeLockedDoors = new ArrayList();
		keyScore = GameObject.Find ("KeyScore").GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {

		float translation_X = Input.GetAxis ("Horizontal" + controller) * speed;
		float translation_Y = Input.GetAxis ("Vertical" + controller) * speed;
        rigid_body.velocity = new Vector2(translation_X, translation_Y);
		player_pos = player.transform.position;

		if (this.gameObject.GetComponentInChildren<Light> ().range < 3) {
			//Application.LoadLevel (1);
            SceneManager.LoadScene(1);
		}

        if(Input.GetKeyDown(KeyCode.E) && toBeLockedDoors.Count > 0)
        {
            /*The index is open for change based on design needs*/
            ((GameObject)toBeLockedDoors[0]).GetComponent<doorComboScript>().LockDoor();
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Key"))
        {
            other.gameObject.SetActive(false);
            keyOwn += 1;
			keyScore.text = keyOwn.ToString () + "/3";
        } else if(other.gameObject.layer == LayerMask.NameToLayer("DoorCombo"))
        {
            other.gameObject.GetComponent<doorComboScript>().OpenDoor();
            toBeLockedDoors.Add(other.gameObject);
		} else if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
		{
			if (keyOwn >= 3) {
				SceneManager.LoadScene("Player_wins");
			}
		}

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("DoorCombo"))
        {
            other.gameObject.GetComponent<doorComboScript>().CloseDoor();
            toBeLockedDoors.Remove(other.gameObject);
        }
    }


}