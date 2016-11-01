using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 15f;
    public float speedCap = 0.89f;
    public string playerNo = "";
    private string horizontalCtrl = "Horizontal_P";
    private string verticalCtrl = "Vertical_P";
    private bool dead = false;

    //private Vector3 startPos;
    //guys we need to add 2 more players

    private Rigidbody2D theRigidBody;
    
	// Use this for initialization
	void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();
        horizontalCtrl += playerNo;
        verticalCtrl += playerNo;
        Debug.Log(horizontalCtrl + " " + verticalCtrl);
        //startPos = transform.position;
	}
	
    void OnTriggerExit2D(Collider2D other)
    {
        dead = true;
    }

	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis(horizontalCtrl);
        float inputY = Input.GetAxis(verticalCtrl);

        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene("Balls");

        if (dead)
        {
            //blah blah make player shrink and fall off, reset game, that shit.
            theRigidBody.velocity = new Vector2(0, 0);
            //dead = false;
        }
        else
        {
            theRigidBody.AddForce(new Vector2(inputX * moveSpeed, inputY * moveSpeed));
            if (theRigidBody.velocity.magnitude > speedCap)
            {
                theRigidBody.velocity.Normalize();
                theRigidBody.velocity = theRigidBody.velocity * speedCap;
            }
        }
    }
}
