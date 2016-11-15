using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryHandler : MonoBehaviour {

    StorySet story;
    string story_string;
    public Text text;

	// Use this for initialization
	void Start () {
        int seed = (int)System.DateTime.Now.Ticks;
        PlayerPrefs.SetInt("RandomSeedStory", seed);
        StoryGenerator gen = GameObject.Find("StoryStuff").GetComponent<StoryGenerator>();
        story = gen.generate_story();
        story_string = "" + story.story_1 + "\n\n" + story.story_2 + "\n\n" + story.story_3 + "\n\n" + story.story_4;
        text = GameObject.Find("StoryText").GetComponent<Text>();
        text.text = story_string;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Yes");
        bool key = Input.GetKey("down");
        if (key)
        {
            Application.LoadLevel("UsingTiles");
        }
	}
}
