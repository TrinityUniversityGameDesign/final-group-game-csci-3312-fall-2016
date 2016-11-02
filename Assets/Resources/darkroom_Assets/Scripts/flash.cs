﻿using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

    // Use this for initialization
    public GameObject enemy;
    public int lightIntensity;
    private Light lightSource;
    private SpriteRenderer spriteRenderer;

	void Start () {
        lightSource = enemy.GetComponent<Light>();
        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        lightSource.intensity = 0;
        spriteRenderer.color = new Color(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        lightSource.transform.position = new Vector3(enemy.transform.position.x + 2, enemy.transform.position.y, enemy.transform.position.z);
        float flash = Input.GetAxisRaw("Flash");
        if(flash > 0)
        {
            Debug.Log("space hit");
            FlashMap();
        }

    }

    private void FlashMap()
    {
        spriteRenderer.color = new Color(255, 255, 255);    
        lightSource.intensity = lightIntensity;
        StartCoroutine(ExecuteAfterTime(0.2f));  

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        lightSource.intensity = 0;
        spriteRenderer.color = new Color(0,0,0);


    }
}
