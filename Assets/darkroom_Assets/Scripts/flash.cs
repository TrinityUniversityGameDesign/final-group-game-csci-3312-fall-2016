using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

    // Use this for initialization
    public GameObject[] rooms;
	void Start () {
        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float flash = Input.GetAxisRaw("Flash");
        if(flash > 0)
        {
            Debug.Log("space hit");
            FlashMap();
        }

    }

    private void FlashMap()
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(true);
        }
        StartCoroutine(ExecuteAfterTime(0.2f));  

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

       foreach(GameObject room in rooms)
        {
            room.SetActive(false);
        }
    }
}
