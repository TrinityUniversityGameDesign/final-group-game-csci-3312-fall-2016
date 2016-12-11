using UnityEngine;
using System.Collections;

public class enemy_movement : MonoBehaviour {

    public float speed = .05f;
    public int controller;
    private Rigidbody2D rigid_body;
    public GameObject player;
    Vector3 player_pos;
    public GlobalPlayerControllerScript gameCont;


    // Use this for initialization
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        player_pos = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        float translation_X = Input.GetAxis(gameCont.players[controller].hor) * speed;
        float translation_Y = Input.GetAxis(gameCont.players[controller].vert) * speed;
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
