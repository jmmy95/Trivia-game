using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionManager : MonoBehaviour
{
    
    public Text questionText;

    public Text scoreText;

    public Text timeScore;

    public Text FinalScore;

    public Button[] replyButtons;

    public QuestionsData questionData;//Reference to the scriptable object.

    public GameObject Right;

    public GameObject Wrong;

    public GameObject GameOver;

    private int currentQueston = 0;

    private static int score = 0;

    private void Start()
    {
        score = 0;
        SetQuestion(currentQueston);
        Right.gameObject.SetActive(false);
        Wrong.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
    }

    void SetQuestion(int questionIndex)
    {
        questionText.text = questionData.questions[questionIndex].questionText;
        foreach (Button r in replyButtons)
        {
            r.onClick.RemoveAllListeners();
        }

        for (int i = 0; i < replyButtons.Length; i++)
        {
            replyButtons[i].GetComponentInChildren<Text>().text = questionData.questions[questionIndex].replies[i];
            int replyIndex = i;
            replyButtons[i].onClick.AddListener(() =>
            {
                CheckReply(replyIndex);
            });
        }
    }

    void CheckReply(int replyIndex)
    {
        if (replyIndex == questionData.questions[currentQueston].correctReplyIndex)
        {
            score++;
            scoreText.text = "Score: " + score;

            Right.gameObject.SetActive(true);

            foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }

            StartCoroutine(Next());
        }
        else
        {
            Wrong.gameObject.SetActive(true );

            foreach(Button r in replyButtons)
            {
                r.interactable=false;

                StartCoroutine(Next());
            }
        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        currentQueston++;
        
        if(currentQueston < questionData.questions.Length)
        {
            Reset();
        }
        else
        {
            GameOver.SetActive(true ); 

            float scorePercantage = (float)score /questionData.questions.Length*100;

            FinalScore.text = "You Scored: " + scorePercantage.ToString("F0") +"%";

            if(scorePercantage < 50)
            {
                FinalScore.text += "\nGame Over";
            }
            else if(scorePercantage < 60)
            {
                FinalScore.text += "\nKeep Trying";
            }
            else if(scorePercantage < 70)
            {
                FinalScore.text += "\nGood Joob";
            }
            else if( scorePercantage < 80)
            {
                FinalScore.text += "\nWell Done";
            }
            else
            {
                FinalScore.text += "\n You are Fantastic";
            }
        }
    }

    public void Reset()
    {
        Right.SetActive(false);
        Wrong.SetActive(false);

        foreach(Button r in replyButtons)
        {
            r.interactable = true;

            SetQuestion(currentQueston);
        }
    }
}
