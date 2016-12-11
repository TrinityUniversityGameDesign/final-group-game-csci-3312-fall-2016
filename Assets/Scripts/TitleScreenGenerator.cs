using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Crosstales.RTVoice.Model;
using Crosstales.RTVoice.Util;

public class TitleScreenGenerator : MonoBehaviour
{

    StorySet story;
    public Text text;

    object get_random(object[] elems)
    {
        return elems[Random.Range(0, elems.Length)];
    }

    // Use this for initialization
    void Start()
    {
        StoryGenerator gen = GameObject.Find("TitleMaker").GetComponent<StoryGenerator>();
        int seed = (int)System.DateTime.Now.Ticks;
        PlayerPrefs.SetInt("RandomSeedStory", seed);
        PlayerPrefs.SetInt("StoryNumber", 0);
        string[] games = { "TitleJacketSmackIt", "MainScene", "Balls" };
        int f;
        int s;
        int t;
        f = Random.Range(0, 3);
        s = Random.Range(0, 3);
        while (f == s)
        {
            s = Random.Range(0, 3);
        }
        t = Random.Range(0, 3);
        while (s == t || f == t )
        {
            t = Random.Range(0, 3);
        }
        // Show story part 1 before this
        PlayerPrefs.SetString("GameNumber1", games[f]);
        Debug.Log(PlayerPrefs.GetString("GameNumber1"));
        // Show story part 2 before this
        PlayerPrefs.SetString("GameNumber2", games[s]);
        Debug.Log(PlayerPrefs.GetString("GameNumber2"));
        // Show story part 3 before this
        PlayerPrefs.SetString("GameNumber3", games[t]);
        Debug.Log(PlayerPrefs.GetString("GameNumber3"));
        // Show story part 4 before this, final piece
        PlayerPrefs.SetString("GameNumber4", "UsingTiles");
        Debug.Log(PlayerPrefs.GetString("GameNumber4"));

        story = gen.generate_story();
        PlayerPrefs.SetString("HiddenTemple", story.title[1]);
        PlayerPrefs.SetString("ArtifactName", story.artifact);
        text = GameObject.Find("Title").GetComponent<Text>();
        text.text = story.title[0] + " " + story.title[1];

        //Crosstales.RTVoice.Speaker.Speak(text.text, GetComponent<AudioSource>(), null, true, 0.26f, 1, "", 2f);
        string[] fonts = {"BlackCastleMF", "burritos",
                          "dum1", "JUNGLEFE", "lightmorning",
                          "Luminari", "Mayan", "Taibaijan",
                          "Trattatello"};
        string random_font = get_random(fonts) as string;
        PlayerPrefs.SetString("font_name", random_font);


        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
