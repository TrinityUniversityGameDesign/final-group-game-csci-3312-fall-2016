﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrivaController : MonoBehaviour
{
    public bool invoked = false;
    public Color Highest;
    public Color Lowest;
    public Text txtScore;
    public int question = -1;
    int score = 1000;
    public GameObject controller;
    public Image scoreBar;
    private int readTime = 20;
    private int answers;
    StorySet story;
    public char correct_answer;
    public Text question_text;
    public Text answer_a;
    public Text answer_b;
    public Text answer_x;
    public Text answer_y;
    Question[] questions;
    public GameObject[] players;
    int numPlayers;
    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("NumPlayers", 4);
        numPlayers = PlayerPrefs.GetInt("NumPlayers");
        players = GameObject.FindGameObjectsWithTag("Player");
        story = GameObject.Find("StoryStuff").GetComponent<StoryGenerator>().generate_story();
        question_text = GameObject.Find("QuestionText").GetComponent<Text>();
        answer_a = GameObject.Find("button_A_text").GetComponent<Text>();
        answer_b = GameObject.Find("button_B_text").GetComponent<Text>();
        answer_x = GameObject.Find("button_X_text").GetComponent<Text>();
        answer_y = GameObject.Find("button_Y_text").GetComponent<Text>();
        questions = new Question[4];
        questions[0] = story.question_1;
        questions[1] = story.question_2;
        questions[2] = story.question_3;
        questions[3] = story.question_4;
        set_cur_question();
    }

    // Update is called once per frame
    void Update()
    {

        if (questionIsDone() && !invoked)
        {
            AudioClip a = Resources.Load<AudioClip>("Sounds/TriviaSounds/coins");
            GetComponent<AudioSource>().clip = a;
            //GetComponent<AudioSource>().time = 0.8f + Random.value / 10f;
            GetComponent<AudioSource>().Play();

            if (question == 3)
            {
                Invoke("changeToEnd", 3f);
                invoked = true;
            }
            else
            {
                Invoke("set_cur_question", 3f);
                invoked = true;

            }
            if (correct_answer == 'a')
            {
                answer_b.text = "";
                answer_x.text = "";
                answer_y.text = "";
            }
            else if (correct_answer == 'b')
            {
                answer_a.text = "";
                answer_x.text = "";
                answer_y.text = ""; 
            }
            else if(correct_answer == 'y')
            {
                answer_a.text = "";
                answer_b.text = "";
                answer_x.text = "";
            }
            else if(correct_answer == 'x')
            {
                answer_a.text = "";
                answer_b.text = "";
                answer_y.text = "";
            }
            //set_cur_question();
        }
        else if (!invoked)
        {
            if (readTime == 0 && score > 1)
                score -= 2;
            else if (readTime > 0)
                readTime--;
            txtScore.text = score.ToString();


            scoreBar.fillAmount = (score / 1000f);
            txtScore.color = Color.Lerp(Lowest, Highest, scoreBar.fillAmount);
        }
    }


    void changeToEnd()
    {
        SceneManager.LoadScene("TriviaEnd");
    }
    void set_cur_question()
    {
        invoked = false;
        question += 1;
        answers = 0;
        score = 1000;
        readTime = 20;

        question_text.text = questions[question].question;
        answer_a.text = questions[question].choices[0];
        answer_b.text = questions[question].choices[1];
        answer_x.text = questions[question].choices[2];
        answer_y.text = questions[question].choices[3];
        char[] ops = { 'a', 'b', 'x', 'y' };
        for (int i = 0; i < 4; i++)
        {
            if (questions[question].choices[i] == questions[question].answer)
            {
                correct_answer = ops[i];
            }
        }
        foreach (GameObject player in players)
        {
            TriviaPlayer a = player.GetComponent<TriviaPlayer>();
            a.restart();
        }
    }

    public int amIRight(char answer)
    {
        answers += 1;
        if (answer == correct_answer)
            return score;
        else
            return 0;
    }
    public bool canIAnswer()
    {
        if (readTime == 0 && score > 0)
            return true;
        else
            return false;
    }
    public bool questionIsDone()
    {
        if (answers == numPlayers || score == 0)
            return true;
        else
            return false;

    }
}
