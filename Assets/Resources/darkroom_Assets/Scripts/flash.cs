using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

    // Use this for initialization
    public GameObject enemy;
    public Light lightSource;
	void Start () {
        lightSource = enemy.GetComponent<Light>();
        

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
       
        StartCoroutine(ExecuteAfterTime(0.2f));  

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

       
    }
}
