using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriviaPlayer : MonoBehaviour
{
	private Image Button;
	public Image A;
	public Image X;
	public Image B;
	public Image Y;
	public Image none;
	public Image check;
    public Image checkSprite;
	public Text txtScore;
	public int preScore = 0;
	public int scoreFromQuestion = 0;
	public int playerNumber;
	bool answered;
	public GameObject controllerGameObject;
	TrivaController controller;
    public string playerString;
    public string playerStringHighest;
    public string playerStringLowest;

    public Image Uniform;
    public Image playerImage;
    //Text/check animation vars
    public AnimationCurve cur;
    float sTime = -1;
    float tTime = -1;
    Vector3 startScale;
    Vector3 startScaleText;
    public float fillSpeed;

    // Use this for initialization
    int numPlayers;
    void Start ()
	{
      //  PlayerPrefs.SetInt("NumPlayers", 4);
        numPlayers = PlayerPrefs.GetInt("NumPlayers");
        if (numPlayers < playerNumber)
        {
            txtScore.text = "";
            check.fillAmount = 0;
            Uniform.fillAmount = 0;
            playerImage.fillAmount = 0;

        }
        else
        {
            Button = check;
            answered = false;
            controller = controllerGameObject.GetComponent<TrivaController>();
            check.fillAmount = 0;
            startScale = check.transform.localScale;
            startScaleText = txtScore.gameObject.transform.localScale;
            playerString = "Trivia Player " + playerNumber;
            playerStringHighest = "Highest Trivia Player " + playerNumber;
            playerStringLowest = "Lowest Trivia Player " + playerNumber;
            PlayerPrefs.SetInt(playerStringLowest, 1001);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlayers >= playerNumber)
        {
            if (answered)
            {
                if (sTime == -1)
                    sTime = 0;
                sTime += Time.deltaTime;
                if (check.fillAmount < 1)
                    check.fillAmount = sTime * fillSpeed;
                check.transform.localScale = startScale * cur.Evaluate(sTime);
            }
            if (controller.questionIsDone())
            {
                check.sprite = Button.sprite;
                preScore += scoreFromQuestion;
                if (PlayerPrefs.GetInt(playerStringHighest) < scoreFromQuestion)
                    PlayerPrefs.SetInt(playerStringHighest, scoreFromQuestion);
                if (PlayerPrefs.GetInt(playerStringLowest) > scoreFromQuestion && scoreFromQuestion > 0)
                    PlayerPrefs.SetInt(playerStringLowest, scoreFromQuestion);
                scoreFromQuestion = 0;

                if (tTime == -1)
                    tTime = 0;
                tTime += Time.deltaTime;
                txtScore.gameObject.transform.localScale = startScaleText * cur.Evaluate(tTime);


                PlayerPrefs.SetInt(playerString, preScore);
                PlayerPrefs.Save();
            }
            txtScore.text = "Score : " + preScore;
            if (!answered && controller.canIAnswer())
            {
                if (Input.GetAxis("A_P" + playerNumber) > 0)
                {
                    Button = A;
                    answered = true;
                    scoreFromQuestion = controller.amIRight('a');
                }
                else if (Input.GetAxis("X_P" + playerNumber) > 0)
                {
                    Button = X;
                    answered = true;
                    scoreFromQuestion = controller.amIRight('x');
                }
                else if (Input.GetAxis("B_P" + playerNumber) > 0)
                {
                    Button = B;
                    answered = true;
                    scoreFromQuestion = controller.amIRight('b');
                }
                else if (Input.GetAxis("Y_P" + playerNumber) > 0)
                {
                    Button = Y;
                    answered = true;
                    scoreFromQuestion = controller.amIRight('y');
                }
            }
        }
    }
    public void restart()
    {
        answered = false;
        check.fillAmount = 0;
        Button = checkSprite;
        sTime = -1;
        tTime = -1;
        check.sprite = checkSprite.sprite;
    }
}
