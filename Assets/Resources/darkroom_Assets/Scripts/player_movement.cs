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
    Text keyName;
    public int keyOwn = 0;
    private ArrayList toBeLockedDoors;
    AudioSource[] sounds;
    AudioSource footStep;
    AudioSource pickupkey;



	// Use this for initialization
	void Start () {
        float orientation = Mathf.Floor(Random.Range(0f, 3.9f));
        orientation *= 90f;
        //Camera one = Camera.main;
        Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, orientation);
        player.transform.rotation = Quaternion.Euler(0f, 0f, orientation);

		rigid_body = GetComponent<Rigidbody2D>();		
		player_pos = player.transform.position;  
		if (this.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			//this.gameObject.transform.position = new Vector3 (1, 38, 0);
		}
        toBeLockedDoors = new ArrayList();
		keyScore = GameObject.Find ("KeyScore").GetComponent<Text> ();
        keyName = GameObject.Find("KeyName").GetComponent<Text>();
        keyName.text = "Artifacts:";

        sounds = GetComponents<AudioSource>();
        footStep = sounds[0];
        pickupkey = sounds[1];
    }

	// Update is called once per frame
	void Update () {

		float translation_X = Input.GetAxis ("Horizontal_P" + controller) * speed;
		float translation_Y = Input.GetAxis ("Vertical_P" + controller) * speed;
        rigid_body.velocity = new Vector2(translation_X, translation_Y);
        Vector3 old_position = player_pos;
        player_pos = player.transform.position;

        if(old_position != player_pos)
        {
            footStep.Play();
        }
        else
        {
            footStep.Stop();
        }


		if (this.gameObject.GetComponentInChildren<Light> ().range < 3) {
			//Application.LoadLevel (1);
            SceneManager.LoadScene(1);
		}

        if(Input.GetAxis("A_P" + controller)> 0 && toBeLockedDoors.Count > 0)
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
            pickupkey.Play();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("DoorCombo"))
        {
            other.gameObject.GetComponent<doorComboScript>().OpenDoor();
            toBeLockedDoors.Add(other.gameObject);
		}
        else if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
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