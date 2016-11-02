using UnityEngine;
using System.Collections;

public class PlayerPanelScript : MonoBehaviour {
	public string playerName;
	GameObject player;

	int idolPieces;
	bool isDead;

	Vector3 dumpPosition;

	Vector3 skullStartPos;
	GameObject skull;

	// Use this for initialization
	void Start () {
		player = GameObject.Find (playerName) as GameObject;

		dumpPosition = new Vector3(1000,1000,1000);
		idolPieces = 0;
		isDead = false;

		//teleport skull away
		skull = transform.Find ("Skull").gameObject;
		skullStartPos = skull.transform.position;
		skull.transform.position = dumpPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetIsDead(bool b){
		isDead = b;
		//make skull visible
		if (isDead) {
			skull.transform.position = skullStartPos;
		} else {
			skull.transform.position = dumpPosition;
		}
	}
	public void GiveIdolPiece(){
		if (idolPieces < 2) {
			idolPieces++;
		}
	}
	public GameObject GetPlayerObject(){
		return player;
	}

}
