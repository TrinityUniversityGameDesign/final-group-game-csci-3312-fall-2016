using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PlayerPanelScript : MonoBehaviour {
	public GameObject player;

	int idolPieces;
	bool isDead;

	Vector3 dumpPosition;

	Vector3 skullStartPos;
	GameObject skull;

	Text pointsText;

	// Use this for initialization
	void Start () {
        if (!player.activeSelf) gameObject.SetActive(false);
        else
        {
            pointsText = transform.Find("PointsText").GetComponent<Text>();
            //player = GameObject.Find (playerName) as GameObject;
            pointsText.text = "score: 0";

            dumpPosition = new Vector3(1000, 1000, 1000);
            idolPieces = 0;
            isDead = false;

            //teleport skull away
            skull = transform.Find("Skull").gameObject;
            skullStartPos = skull.transform.position;
            skull.transform.position = dumpPosition;

            gameObject.transform.FindChild("PlayerNum").gameObject.GetComponent<Text>().text = player.name;
            transform.GetComponent<Image>().color = player.GetComponent<SpriteRenderer>().color;
            transform.GetComponent<Image>().color = new Color(transform.GetComponent<Image>().color.r, transform.GetComponent<Image>().color.g, transform.GetComponent<Image>().color.b, 0.4f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerMovement_Jacket> ().IsDead () && !isDead) {
			SetIsDead (true);
		}
		if (!player.GetComponent<PlayerMovement_Jacket> ().IsDead () && isDead) {
			SetIsDead (false);
		}
		pointsText.text = "points " + player.GetComponent<PlayerMovement_Jacket> ().GetPoints ();
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
