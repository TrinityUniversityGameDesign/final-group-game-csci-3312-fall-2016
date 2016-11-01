using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

    // Use this for initialization
    public GameObject enemy;
    private Light lightSource;
	void Start () {
        lightSource = enemy.GetComponent<Light>();
        lightSource.intensity = 0;

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
        lightSource.intensity = 8;
        StartCoroutine(ExecuteAfterTime(0.2f));  

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        lightSource.intensity = 0;


    }
}
