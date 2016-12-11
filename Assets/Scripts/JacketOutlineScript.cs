using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JacketOutlineScript : MonoBehaviour {
	int direction = 1;

	private Color dotsColor;

	public string jacketName;
	GameObject jacketObject;
	JacketScript jacketScript;

	public string playerString;
	GameObject playerObject;



	GameObject circleObject;
	List<GameObject> circleList;

	float playerPosX = 0;
	float playerPosY = 0;
	float playerPosZ = 0;

	//number of pieces making up the cirlce
	private int pieces;

	//radius for the circle
	public float radius;

	//dots per radius
	private int dotsPerRadius;

	// Use this for initialization
	void Start () {
        dotsColor = gameObject.transform.parent.parent.GetComponent<SpriteRenderer>().color;
            
		dotsPerRadius = 6;
		playerObject = GameObject.Find (playerString) as GameObject;


		//find jacket object
		//find player
		jacketObject = GameObject.Find(jacketName) as GameObject;
		jacketScript = jacketObject.GetComponent<JacketScript> ();
		//-----------------
		circleObject = Resources.Load ("Prefabs/Circle") as GameObject;

		circleObject.GetComponent<SpriteRenderer> ().color = dotsColor;
		circleList = new List<GameObject>();
		DrawCircle ();
	}

	void DrawCircle ()
	{
		pieces = (int)(radius*dotsPerRadius);

		//remove excess circles if pieces goes down
		while (circleList.Count > pieces) {
			Destroy(circleList[0]);
			circleList.RemoveAt (0);
		}

		//add new circles if pieces goes up
		while (circleList.Count < pieces) {
			GameObject spawnedCircle = Instantiate (circleObject, new Vector3 (0, 0, 1.1f), Quaternion.identity) as GameObject;
			circleList.Add(spawnedCircle);
            spawnedCircle.GetComponent<SpriteRenderer>().color = dotsColor;

        }
			
		float posX = 0f;
		float posY = 0f;
		float posZ = 1.1f;

		float angle = 0f;
		float anglePerPiece = (360.0f / pieces);

		for (int i = 0; i < pieces; i++)
		{
			posX = Mathf.Sin(Mathf.Deg2Rad*angle)*radius;
			posY = Mathf.Cos(Mathf.Deg2Rad*angle)*radius;
			circleList [i].transform.position = new Vector3(posX + transform.position.x, posY + transform.position.y, posZ);

			angle += anglePerPiece;
		}
	}

	// Update is called once per frame
	void Update () {
		ChangeDotPositions();
		DrawCircle ();

		if (radius > 5) {
			direction = -1;
		}if (radius < 1) {
			direction = 1;
		}
	
		//radius += .01f * direction;
	}

	//get Radius and position from Player
	void ChangeDotPositions(){

		//get air level
		//radius = air level
		radius = ((jacketScript.jacketScale)/2f)*(playerObject.transform.localScale.y);
		//-----------------
	}
}
