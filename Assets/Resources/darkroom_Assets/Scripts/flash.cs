using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

    // Use this for initialization
    public GameObject enemy;
    public int lightIntensity;
    public GameObject lightObject;
    private Light lightSource;
    private SpriteRenderer spriteRenderer;
    public int controller;

    public GlobalPlayerControllerScript gameCont;



    void Start () {
        gameCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalPlayerControllerScript>();
        lightSource = lightObject.GetComponent<Light>();
        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        lightSource.intensity = 0;
        spriteRenderer.color = new Color(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        
        //float flash = Input.GetAxisRaw(gameCont.players[controller].ABut);
        bool flash = Input.GetButton(gameCont.players[controller].ABut);
        if(flash)
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
