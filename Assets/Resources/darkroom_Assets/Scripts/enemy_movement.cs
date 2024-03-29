﻿using UnityEngine;
using System.Collections;

public class enemy_movement : MonoBehaviour {

    public float speed = .05f;
    public int controller;
    private Rigidbody2D rigid_body;
    public GameObject player;
    Vector3 player_pos;
    public GlobalPlayerControllerScript gameCont;
    //  public int mapOrientation;
    Color tmpColor;


    // Use this for initialization
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        player_pos = player.transform.position;
        gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
        // player.transform.rotation = Quaternion.Euler(0f, 0f, mapOrientation);
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("player" +controller+"_color"), out tmpColor);

        //transform.FindChild("enemyLight").GetComponent<Light>().color = tmpColor;
        GetComponentInChildren<Light>().color = tmpColor;
        Debug.Log(tmpColor);
    }

    // Update is called once per frame
    void Update()
    {

        float translation_X = Input.GetAxis(gameCont.players[controller].hor) * speed;
        float translation_Y = Input.GetAxis(gameCont.players[controller].vert) * speed;
  /*      switch ((int)mapOrientation)
        {
            case 0:
                translation_X = translation_X;
                translation_Y = translation_Y;
                break;
            case 90:
                float transx = translation_X;
                translation_X = translation_Y;
                translation_Y = -transx;
                break;
            case 180:
                translation_X = -translation_X;
                translation_Y = -translation_Y;
                break;
            case 270:
                float transx2 = translation_X;
                translation_X = -translation_Y;
                translation_Y = transx2;
                break;
        }*/
        rigid_body.velocity = new Vector2(translation_X, translation_Y);
        player_pos = player.transform.position;

        /*if (this.gameObject.GetComponentInChildren<Light>().range < 3)
        {
            SceneManager.LoadScene(1);
        }*/

        /*if (Input.GetAxis("A_P" + controller) > 0 && toBeLockedDoors.Count > 0)
        {
            ((GameObject)toBeLockedDoors[0]).GetComponent<doorComboScript>().LockDoor();
        }*/

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.gameObject.layer == LayerMask.NameToLayer("Key"))
        {
            other.gameObject.SetActive(false);
            keyOwn += 1;
            keyScore.text = keyOwn.ToString() + "/3";
        }*/

        if (other.gameObject.layer == LayerMask.NameToLayer("DoorCombo"))
        {
            other.gameObject.GetComponent<doorComboScript>().OpenDoor();
            //toBeLockedDoors.Add(other.gameObject);
        }
        /*
        else if (other.gameObject.layer == LayerMask.NameToLayer("Portal"))
        {
            if (keyOwn >= 3)
            {
                SceneManager.LoadScene("Player_wins");
            }
        }*/

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DoorCombo"))
        {
            other.gameObject.GetComponent<doorComboScript>().CloseDoor();
            //toBeLockedDoors.Remove(other.gameObject);
        }
    }
}
