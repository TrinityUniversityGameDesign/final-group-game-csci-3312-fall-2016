using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float speedCap = 2.5f;
    public int playerNo = 1;
    public float customFriction = 0.1f;
    private string horizontalCtrl = "Horizontal_P";
    private string verticalCtrl = "Vertical_P";
    private bool dead = false;
    private Animator animationController;
    private float animSpeedMult = 1.5f; //Meant to increase the speed of the animation of the player

    private Quaternion originalRotation;

    private Rigidbody2D theRigidBody;

    void Start()
    {
        theRigidBody = GetComponent<Rigidbody2D>();
        horizontalCtrl += playerNo.ToString();
        verticalCtrl += playerNo.ToString();
        animationController = GetComponent<Animator>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dead = true;
    }

    //put OnTriggerEnter for the death tag here

    // Update is called once per frame
    void Update()
    {
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
            else
            {
                gameObject.SetActive(false);
                //adds points to player score
                UIManager.playerPlacing.Push(gameObject.name);
                UIManager.playerPoints[playerNo-1] += UIManager.playerPlacing.Count;
            }
        }
        else
        {
            if (UIManager.gameWon)
            {
                theRigidBody.velocity = new Vector3(0, 0, 0);
                animationController.speed = 0;
            }
            else
            {
                theRigidBody.AddForce(new Vector2(inputX * moveSpeed, inputY * moveSpeed));
                if (theRigidBody.velocity.magnitude > speedCap) //Meant to limit the player's top Speed
                {
                    Vector2 temp = theRigidBody.velocity;
                    temp.Normalize();
                    if ((theRigidBody.velocity - temp * customFriction).magnitude < speedCap)
                    { //If reducing speed would reduce it to less than speedcap, only go to speedcap
                        theRigidBody.velocity = temp * speedCap;
                    }
                    else
                    {
                        theRigidBody.velocity = theRigidBody.velocity - (temp * customFriction); //Otherwise just steadily reduce speed
                    }
                }
                Vector3 tempVel = theRigidBody.velocity;
                animationController.speed = animSpeedMult * Mathf.Abs(theRigidBody.velocity.magnitude);
                if (theRigidBody.velocity.magnitude > 0)
                {
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, tempVel); //Currently turns towards current velocity, will probably change to turn towards player input. Maybe smooth using lerp.
                }
            }
        }
    }
}
