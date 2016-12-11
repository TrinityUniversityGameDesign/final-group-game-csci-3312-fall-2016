﻿using UnityEngine;
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
    private Queue lockedDoors;


    AudioSource[] sounds;
    AudioSource footStep;
    AudioSource pickupkey;
    public GlobalPlayerControllerScript gameCont;

    void Awake() { gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>(); }





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

        lockedDoors = new Queue();

        int p1score = PlayerPrefs.GetInt("player1_score");
        int p2score = PlayerPrefs.GetInt("player2_score");
        int p3score = PlayerPrefs.GetInt("player3_score");
        int p4score = PlayerPrefs.GetInt("player4_score");
        int max = p1score;

        controller = 1;


        if (p2score > max)
        {
            GameObject.Find("orange_enemy").GetComponent<enemy_movement>().controller = controller;
            max = p2score;
            //enemyControllers.Push (controller);
            controller = 2;
        }
        else
        {
            GameObject.Find("orange_enemy").GetComponent<enemy_movement>().controller = 2;
        }
        if (p3score > max)
        {
            GameObject.Find("Enemy (1)").GetComponent<enemy_movement>().controller = controller;
            max = p3score;
            controller = 3;

        }
        else
        {
            GameObject.Find("Enemy (1)").GetComponent<enemy_movement>().controller = 3;
        }

        if (p4score > max)
        {
            GameObject.Find("Enemy (2)").GetComponent<enemy_movement>().controller = controller;
            max = p4score;
            controller = 4;
        }
        else
        {
            GameObject.Find("Enemy (2)").GetComponent<enemy_movement>().controller = 4;
        }



    }

    // Update is called once per frame
    void Update () {

        float translation_X = Input.GetAxis(gameCont.players[controller].hor) * speed;
        float translation_Y = Input.GetAxis(gameCont.players[controller].vert) * speed;



        //        float translation_X = Input.GetAxis ("Horizontal_P" + controller) * speed;
        //        float translation_Y = Input.GetAxis ("Vertical_P" + controller) * speed;



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


        if (Input.GetAxis(gameCont.players[controller].ABut) > 0 && toBeLockedDoors.Count > 0)
        {
            /*The index is open for change based on design needs*/
            ((GameObject)toBeLockedDoors[0]).GetComponent<doorComboScript>().LockDoor();
        }

        //if(Input.GetAxis("A_P" + controller)> 0 && toBeLockedDoors.Count > 0)
        //{
        //    /*The index is open for change based on design needs*/
        //    ((GameObject)toBeLockedDoors[0]).GetComponent<doorComboScript>().LockDoor();
        //}

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