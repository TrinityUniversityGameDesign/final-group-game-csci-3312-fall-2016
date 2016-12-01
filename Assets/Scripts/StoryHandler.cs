using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryHandler : MonoBehaviour {

    StorySet story;
    string story_string;
    public Text text;

	// Use this for initialization
	void Start () {
        StoryGenerator gen = GameObject.Find("StoryStuff").GetComponent<StoryGenerator>();
        int story_number = PlayerPrefs.GetInt("StoryNumber");
        story = gen.generate_story();
        string[] pieces = { story.story_1, story.story_2, story.story_3, story.story_4 };
        story_string = pieces[story_number];
        PlayerPrefs.SetInt("StoryNumber", story_number + 1);
        text = GameObject.Find("StoryText").GetComponent<Text>();
        text.text = story_string;
    }
	
    int get_random()
    {
        return Random.Range(0, 3);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Start_P1") > 0)
        {
            if (PlayerPrefs.GetInt("StoryNumber") == 4)
            {
                Application.LoadLevel("UsingTiles");
            }
            else
            {
                string level = "";
                while (level == "")
                {
                    if (PlayerPrefs.GetInt("ButtonCombinations") == 0 &&
                        get_random() == 1)
                    {
                        level = PlayerPrefs.GetString("FirstButtonsLevel");
                    }
                    else if (PlayerPrefs.GetInt("KnockOffGame") == 0 &&
                        get_random() == 1)
                    {
                        level = PlayerPrefs.GetString("FirstKnockOffGameLevel");
                    }
                    else if (PlayerPrefs.GetInt("InflatableGame") == 0 &&
                        get_random() == 1)
                    {
                        level = PlayerPrefs.GetString("FirstInflatableGameLevel");
                    }
                }
                Application.LoadLevel(level);
            }
        }
	}
}
