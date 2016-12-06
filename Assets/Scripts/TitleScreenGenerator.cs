using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenGenerator : MonoBehaviour
{

    StorySet story;
    public Text text;

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
        PlayerPrefs.SetString("GameNumber1", games[f]);
        Debug.Log(PlayerPrefs.GetString("GameNumber1"));

        PlayerPrefs.SetString("GameNumber2", games[s]);
        Debug.Log(PlayerPrefs.GetString("GameNumber2"));

        PlayerPrefs.SetString("GameNumber3", games[t]);
        Debug.Log(PlayerPrefs.GetString("GameNumber3"));

        PlayerPrefs.SetString("GameNumber4", "UsingTiles");
        Debug.Log(PlayerPrefs.GetString("GameNumber4"));

        story = gen.generate_story();
        PlayerPrefs.SetString("HiddenTemple", story.title[1]);
        PlayerPrefs.SetString("ArtifactName", story.artifact);
        text = GameObject.Find("Title").GetComponent<Text>();
        text.text = story.title[0] + " " + story.title[1];
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
