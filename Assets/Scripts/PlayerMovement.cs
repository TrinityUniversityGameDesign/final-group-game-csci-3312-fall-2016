using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 15f;
    public float speedCap = 0.89f;
    public string playerNo = "";
	public float customFriction = 0.5f;
    private string horizontalCtrl = "Horizontal_P";
    private string verticalCtrl = "Vertical_P";
    private bool dead = false;

    private Rigidbody2D theRigidBody;
    
	void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();
        horizontalCtrl += playerNo;
        verticalCtrl += playerNo;
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
            theRigidBody.velocity = new Vector2(0, 0);
            //shrinks player until it is almost invisible then removes the player
            if (transform.localScale.x >= 0)
                transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
            else {
                gameObject.SetActive(false);
                UIManager.alivePlayers -= 1;
            }
        }
        else
        {
            theRigidBody.AddForce(new Vector2(inputX * moveSpeed, inputY * moveSpeed));
            if (theRigidBody.velocity.magnitude > speedCap) //Meant to limit the player's top Speed
            {
				Vector2 temp = theRigidBody.velocity;
				temp.Normalize ();
				if ((theRigidBody.velocity - temp * customFriction).magnitude < speedCap) { //If reducing speed would reduce it to less than speedcap, only go to speedcap
					theRigidBody.velocity = temp * speedCap;
				} else {
					theRigidBody.velocity = theRigidBody.velocity - (temp * customFriction); //Otherwise just steadily reduce speed
				}
            }
        }
    }
}
