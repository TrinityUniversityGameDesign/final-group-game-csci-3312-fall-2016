﻿using UnityEngine;
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
        story = gen.generate_story();
        text = GameObject.Find("Title").GetComponent<Text>();
        text.text = story.title[0] + " " + story.title[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}