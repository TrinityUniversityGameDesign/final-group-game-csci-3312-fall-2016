using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryHandler : MonoBehaviour {

    StorySet story;
    string story_string;
    public Text text;
    ArrayList story_sentences;
    public string cur_story_part;
    int cur_sentence = 0;
    float time;
    bool can_press = true;
    ArrayList get_sentences(string story_chunk)
    {
        int i = 0;
        string ret_s = "";
        ArrayList ret = new ArrayList();
        for (int j = 0;j < story_chunk.Length;j++)
        {
            if (story_chunk[j] == '.' && j + 1 < story_chunk.Length &&
                       story_chunk[j + 1] == '.')
            {
                ret_s += "...";
                ret.Add(ret_s);
                return ret;
            }
            else if (story_chunk[j] == '.' )
            {
                ret_s += ".";
                ret.Add(ret_s);
                ret_s = "";
            } 
            else
            {
                ret_s += story_chunk[j];
            }
        }
        return ret;
    }

	// Use this for initialization
	void Start () {
        StoryGenerator gen = GameObject.Find("StoryStuff").GetComponent<StoryGenerator>();
        int story_number = PlayerPrefs.GetInt("StoryNumber");
        story_number = 0;
        Debug.Log("Story Number " + story_number);
        story = gen.generate_story();
        string[] pieces = { story.story_1, story.story_2, story.story_3, story.story_4 };
        Debug.Log("Story Number " + story_number);
        story_string = pieces[story_number];
        Debug.Log("Story Number " + story_number);
        PlayerPrefs.SetInt("StoryNumber", story_number + 1);
        text = GameObject.Find("StoryText").GetComponent<Text>();
        story_sentences = get_sentences(story_string);
        text.text = story_sentences[cur_sentence] as string;
        Crosstales.RTVoice.Speaker.Speak(text.text, GetComponent<AudioSource>(), null, true, 1f, 1, "", 2f);
    }
	
    void get_next_story_chunk()
    {
        cur_sentence += 1;
        text.text = story_sentences[cur_sentence] as string;
        Crosstales.RTVoice.Speaker.Speak(text.text, GetComponent<AudioSource>(), null, true, 1f, 1, "", 2f);
    }

    int get_random()
    {
        return Random.Range(0, 3);
    }

	// Update is called once per frame
	void Update () {
        float axis = Input.GetAxis("Start_P1");
        if (axis > 0 && cur_sentence > story_sentences.Count)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("GameNumber" + 
                                  PlayerPrefs.GetInt("StoryNumber")));

        } else if (axis > 0 && can_press)
        {
            get_next_story_chunk();
            can_press = false;
        } else if (axis <= .005)
        {
            can_press = true;
        }

	}
}
