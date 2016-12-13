using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float speedCap = 2.5f;
    public int playerNo = 1;
    public int numPlayers = 1;
    public float customFriction = 0.1f;
    //private string horizontalCtrl = "Horizontal_P";
    //private string verticalCtrl = "Vertical_P";
    private bool dead = false;
    private Animator animationController;
    private Animator animationController2;
    private float animSpeedMult = 1.5f; //Meant to increase the speed of the animation of the player

    private Quaternion originalRotation;
    private Rigidbody2D theRigidBody;
    private string playerCol;
    private Color col;
    
    private AudioClip[] fallSounds;
    public AudioClip wail1;
    public AudioClip wail2;
    public AudioClip wail3;
    public AudioClip wail4;
    public AudioClip wail5;
    public AudioClip wail6;
    public AudioClip wail7;
    public AudioClip wail8;
    public AudioClip wail9;

    public AudioSource aSource;
    private bool deathsound = true;

    public GlobalPlayerControllerScript gameCont;

    public GameObject player = null;

    void Start()
    {
        numPlayers = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>().num_players;
        Debug.Log(numPlayers);
        Debug.Log("PlayerNo:" + playerNo);

        fallSounds = new AudioClip[] {wail1, wail2, wail3, wail4, wail5, wail6, wail7, wail8, wail9};
        
        aSource = this.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player" + playerNo);
        player.SetActive(true);

        playerCol = PlayerPrefs.GetString("player" + playerNo + "_color");
        ColorUtility.TryParseHtmlString(playerCol, out col);
        player.GetComponent<SpriteRenderer>().color = col;

        if(numPlayers < playerNo)
        {
            player.SetActive(false);
            Debug.Log("does this happen k thanks");
        }
        theRigidBody = GetComponent<Rigidbody2D>();
        animationController = transform.FindChild("TDLegs_0").GetComponent<Animator>();
        animationController2 = transform.FindChild("TDShoulders_0").GetComponent<Animator>();
    }

    void Awake()
    {
        gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dead = true;
    }

    bool IsInsideHole(SpriteRenderer hole, CircleCollider2D player)
    {
        Vector2 holeCenter = hole.bounds.center;
        Vector2 playerCenter = player.bounds.center;
        var distance = Vector3.Distance(holeCenter, playerCenter);
        if (distance < .2)
        {
            return true;
        }
        else return false;
    }

    //put OnTriggerEnter for the death tag here

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis(gameCont.players[playerNo].hor);
        float inputY = Input.GetAxis(gameCont.players[playerNo].vert);

        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene("Balls");

        if (dead)
        {
            theRigidBody.velocity = new Vector2(0, 0);
            int randWail = (int)(Random.value * 8);
            if (deathsound)
            {
                aSource.PlayOneShot(fallSounds[randWail], 1f);
                //yield return new WaitForSeconds(2);
                deathsound = false;
            }
            //shrinks player until it is almost invisible then removes the player
            if (transform.localScale.x >= 0)
                transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
            else
            {
                gameObject.SetActive(false);
                //adds points to player score
                UIManager.playerPlacing.Push(gameObject.name);
                if (UIManager.playerPlacing.Count == 2) UIManager.playerPoints[playerNo-1] += 1;
                if (UIManager.playerPlacing.Count == 3) UIManager.playerPoints[playerNo - 1] += 3;
                //else if (UIManager.playerPlacing.Count == 2) UIManager.playerPoints[playerNo - 1] += 1;
                //else { }
            }
        }
        else
        {
            if (UIManager.gameWon)
            {
                theRigidBody.velocity = new Vector3(0, 0, 0);
                animationController.speed = 0;
                animationController2.speed = 0;
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
                animationController2.speed = animSpeedMult * Mathf.Abs(theRigidBody.velocity.magnitude);
                if (theRigidBody.velocity.magnitude > 0)
                {
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, tempVel); //Currently turns towards current velocity, will probably change to turn towards player input. Maybe smooth using lerp.
                }
                //SpriteRenderer hole = GameObject.FindGameObjectWithTag("Hole").GetComponent<SpriteRenderer>();
                //if (hole.gameObject.activeInHierarchy == true)
                //{
                //    if (IsInsideHole(hole, this.gameObject.GetComponent<CircleCollider2D>()))
                //    {
                //        dead = true;
                //    }
                //}
                if(GameObject.FindGameObjectWithTag("Hole") != null)
                {
                    SpriteRenderer hole = GameObject.FindGameObjectWithTag("Hole").GetComponent<SpriteRenderer>();
                    if(IsInsideHole(hole, this.gameObject.GetComponent<CircleCollider2D>()))
                    {
                        dead = true;
                    }
                }
                
            }
        }
    }
}
