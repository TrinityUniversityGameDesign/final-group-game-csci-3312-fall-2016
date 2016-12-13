using UnityEngine;
using System.Collections;

public class BallsMusicScript : MonoBehaviour {


    public GameObject stage;
    public AudioClip iceSong;
    public AudioClip mudSong;
    public AudioClip lavaSong;
    public AudioClip[] soundEffect;
    public AudioClip stageEffect;

    public AudioSource aSource;
    
    // Use this for initialization
    void Start () {
        Random rnd = new Random();
        int randStage = (int)(Random.value * 3);
        aSource = this.GetComponent<AudioSource>();
        Debug.Log("randStage: " + randStage);
        if (randStage == 0)
        {
            stage = GameObject.FindGameObjectWithTag("Stage1");
            if(!stage.activeSelf)
                stage.SetActive(true);
            if (GameObject.FindGameObjectWithTag("Stage2").activeSelf)
                GameObject.FindGameObjectWithTag("Stage2").SetActive(false);
            if (GameObject.FindGameObjectWithTag("Stage3").activeSelf)
                GameObject.FindGameObjectWithTag("Stage3").SetActive(false);
            aSource.clip = iceSong;
            aSource.Play();
            

        }
        else if (randStage == 1)
        {
            stage = GameObject.FindGameObjectWithTag("Stage2");
            if(!stage.activeSelf)
            {
                stage.SetActive(true);
            }
            if (GameObject.FindGameObjectWithTag("Stage1").activeSelf) 
                GameObject.FindGameObjectWithTag("Stage1").SetActive(false);
            if(GameObject.FindGameObjectWithTag("Stage3").activeSelf)
                GameObject.FindGameObjectWithTag("Stage3").SetActive(false);
            aSource.clip = mudSong;
            aSource.Play();
        }
        else if (randStage >= 2)
        {
            stage = GameObject.FindGameObjectWithTag("Stage3");
            if(!stage.activeSelf)
                stage.SetActive(true);
            if (GameObject.FindGameObjectWithTag("Stage2").activeSelf)
                GameObject.FindGameObjectWithTag("Stage2").SetActive(false);
            if (GameObject.FindGameObjectWithTag("Stage1").activeSelf)
                GameObject.FindGameObjectWithTag("Stage1").SetActive(false);
            aSource.clip = lavaSong;
            aSource.Play();

        }
        if(stage != null)
        {
            Debug.Log("stage not null");
        }else
            Debug.Log("stage is null");
    }
	
    
	// Update is called once per frame
	void Update () {
	    
	}
}
