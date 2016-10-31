using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 15f;
    public float speedCap = 0.89f;
    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";

    //private Vector3 startPos;

    private Rigidbody2D theRigidBody;
    
	// Use this for initialization
	void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();
        //startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis(horizontalCtrl);
        float inputY = Input.GetAxis(verticalCtrl);

        theRigidBody.AddForce(new Vector2(inputX * moveSpeed, inputY * moveSpeed));
        if(theRigidBody.velocity.magnitude > speedCap)
        {
            theRigidBody.velocity.Normalize();
            theRigidBody.velocity = theRigidBody.velocity * speedCap; 
        }
    }
}
