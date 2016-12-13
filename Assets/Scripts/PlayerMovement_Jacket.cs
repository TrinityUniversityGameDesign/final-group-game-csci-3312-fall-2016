using UnityEngine;
using System.Collections;

public class PlayerMovement_Jacket : MonoBehaviour {
	//Samuel's stuff
	private bool isDead = false;
	private int points = 0;
    private Vector3 originalSize;
	private Vector3 dumpPosition = new Vector3(10000,10000,10000);
	private Vector3 spawnPosition;

	public int playerNum;
	public float walkSpeed;
	public float dashSpeed;
	public float dashRegeneration;

	private Rigidbody2D rigid;
	private bool canDash = true;

	private string vertAxis;
	private string horAxis;
	private string dashButton;

	public GameObject deathSprite;
    public GameObject ScoreManager;

    private Animator animationController;

	GameObject jacket;
	JacketScript jacketScript;

	public string jacketName;

    public GlobalPlayerControllerScript gameCont;
    void Awake() { gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>(); }

    // Use this for initialization
    void Start () {
		jacket = GameObject.Find (jacketName) as GameObject;
		jacketScript = jacket.GetComponent<JacketScript> ();
		spawnPosition = transform.position;
		rigid = GetComponent<Rigidbody2D> ();
        //Input.GetButtonDown(gameCont.playerNUM_in.ABut)
        //string playerNum2 = "player" + playerNum.ToString() + "_in";
        //vertAxis = "Vertical_P" + playerNum.ToString(); gameCont.players[playerNum].ABut;
        vertAxis = gameCont.players[playerNum].vert;
        horAxis = gameCont.players[playerNum].hor;
        //horAxis = "Horizontal_P" + playerNum.ToString();
		//dashButton = "B_P" + playerNum.ToString();
        animationController = gameObject.GetComponent<Animator>();
        originalSize = transform.localScale;
		deathSprite.transform.position = dumpPosition;
    }
	
	// Update is called once per frame
	void Update () {

        //float x = Input.GetAxis(horAxis);
        //float y = Input.GetAxis(vertAxis);
		rigid.velocity = new Vector2 (Input.GetAxis(horAxis) * walkSpeed, Input.GetAxis(vertAxis) * walkSpeed);
        //transform.localRotation = Quaternion.Euler(Input.GetAxisRaw(horAxis), Quaternion.identity.y, Input.GetAxisRaw(horAxis) * 90);
        //rigidQuaternion.Angle(transform.rotation, target.rotation);
        //Debug.Log(Input.GetAxis(horAxis));
        if(Input.GetAxisRaw(horAxis)!=0 || Input.GetAxisRaw(vertAxis) != 0) animationController.SetBool("isWalking", true);
        else animationController.SetBool("isWalking", false);

        /*
        if (Input.GetButtonDown(dashButton))
        {
            if(canDash)
            {
                rigid.AddForce(new Vector2(rigid.velocity.x * dashSpeed, rigid.velocity.y * dashSpeed));
                canDash = false;
                StartCoroutine(ResetDash());
            }
        }
        */
            /*
            //TODO : Add dashing in
            float dash = Input.GetAxis(dashButton);
            if (canDash && dash > 0) {
                rigid.AddForce (new Vector2 (rigid.velocity.x * dash * dashSpeed, rigid.velocity.y * dash * dashSpeed));
                canDash = false;
                StartCoroutine (ResetDash ());
            }
            */
            //ugly, fix later
            if ((transform.position.x < -7 || transform.position.x > 7) && !isDead) {
			OnDeath ();
		} else if ((transform.position.y < -4 || transform.position.y > 3.5)&&!isDead) {
			OnDeath ();
		}
	}

	IEnumerator ResetDash() {
		yield return new WaitForSeconds (dashRegeneration);
		canDash = true;
	}

    /*
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Death") && gameObject.CompareTag("Player")) {
			OnDeath ();
		}
	}
    */

	//Samuel's Functions;
	public void OnDeath() {
		deathSprite.transform.position = transform.position;
		StartCoroutine (despawnSkull());
		//Destroy (gameObject);
		isDead = true;
		//Debug.Log("I died!");
        /*while(transform.localScale.x>0)
        {
            //transform.lo
            transform.localScale -= new Vector3(0.0001f, 0.0001f, 0.0f);
        }*/
		transform.position = dumpPosition;
        //transform.localScale.Set(originalSize.x,originalSize.y,originalSize.z);
	}

	private IEnumerator despawnSkull(){
		yield return new WaitForSeconds(2);
		deathSprite.transform.position = dumpPosition;
	}
	public void Respawn(){
		//teleport player back to start
		isDead = false;
		transform.position = spawnPosition;
		//reset Jacket
		jacketScript.ResetJacket();
	}
	public void AddPoint(){
		points++;
	}
	public int GetPoints(){
		return points;
	}
	public void SetDead(bool d){
		isDead = d;
	}
	public bool IsDead(){
		return isDead;
	}
}
