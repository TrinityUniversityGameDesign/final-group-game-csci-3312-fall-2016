using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JacketOutlineScript : MonoBehaviour {
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

	public string playerName;

	//dots per radius
	public int dotsPerRadius;

	// Use this for initialization
	void Start () {
		//find player object

		//-----------------
		circleObject = Resources.Load ("Prefabs/Circle") as GameObject;
		circleList = new List<GameObject>();
		DrawCircle ();
	}

	void DrawCircle ()
	{
		pieces = (int)(radius*dotsPerRadius);

		//remove excess circles if pieces goes down
		while (circleList.Count > pieces) {
			Destroy(circleList[0]);
		}

		//add new circles if pieces goes up
		while (circleList.Count < pieces) {
			GameObject spawnedCircle = Instantiate (circleObject, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			circleList.Add(spawnedCircle);
		}
			
		float posX = 0f;
		float posY = 0f;
		float posZ = 0f;

		float angle = 50.0f;
		float anglePerPiece = (360.0f / pieces);

		for (int i = 0; i < pieces; i++)
		{
			posX = Mathf.Sin(Mathf.Deg2Rad*angle)*radius;
			posY = Mathf.Cos(Mathf.Deg2Rad*angle)*radius;
			circleList [i].transform.position = new Vector3(posX + transform.position.x, posY + transform.position.y, posZ + transform.position.z);

			angle += anglePerPiece;
		}
	}

	// Update is called once per frame
	void Update () {
		ChangeDotPositions();
		DrawCircle ();
	}

	//get Radius and position from Player
	void ChangeDotPositions(){

		//get air level
		//radius = air level
		//-----------------
	}
}
