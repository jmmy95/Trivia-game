using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class QuestionManager : MonoBehaviour {
    public Text questionText;
    public Text scoreText;
    public Text timeScore;
    public Text FinalScore;
    public Button[] replyButtons;
    public Button[] categoryButtons;  //The buttons for the categories

    // References to ScriptableObjects for each category
    public QuestionsData politicalQuestionsCategory;
    public QuestionsData civilQuestionsCategory;
    public QuestionsData economicQuestionsCategory;
    public QuestionsData socialQuestionsCategory;

    public GameObject Right;
    public GameObject Wrong;
    public GameObject GameOver;

    private QuestionsData selectedQuestions; // To hold the currently active category
    private int currentQuestionIndex;




    private void Start() {
        //Hide the question and reply UI initially
        setQuestionUIActive(false);
        Right.gameObject.SetActive(false);
        Wrong.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
        //Wait for the category selection before starting the game
    }

    public void OnCategorySelected(string Category)
     {
        //determine which category was selected
        switch (Category)
         {
            case "Political":
                selectedQuestions = politicalQuestionsCategory;
                break;
            case "Social":
                selectedQuestions = socialQuestionsCategory;
                break;
            case "Civil":
                selectedQuestions = civilQuestionsCategory;
                break;
            case "Economic":
                selectedQuestions = economicQuestionsCategory;
                break;
        }
        //Hide category buttons and show the first question from the selected category
        SetCategoryUIActive(false);
        setQuestionUIActive(true);
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    private void DisplayQuestion() 
     {
        if (selectedQuestions != null && currentQuestionIndex < selectedQuestions.questions.Length) {
            questionText.text = selectedQuestions.questions[currentQuestionIndex].questionText;

            for (int i = 0; i < replyButtons.Length; i++) {
                replyButtons[i].GetComponentInChildren<Text>().text = selectedQuestions.questions[currentQuestionIndex].replies[i];
                int replyIndex = i; // Capture the index for use in the lambda
                replyButtons[i].onClick.RemoveAllListeners();

                replyButtons[i].onClick.AddListener(() => CheckReply(replyIndex));
            }
        }
    }

    public void CheckReply(int replyIndex) {
        if (replyIndex == selectedQuestions.questions[currentQuestionIndex].correctReplyIndex) {
            // Correct answer logic
            Debug.Log("Correct!");
        } else {
            // Incorrect answer logic
            Debug.Log("Incorrect!");
        }

        // Move to the next question
        currentQuestionIndex++;

        if (currentQuestionIndex < selectedQuestions.questions.Length)
         {
            DisplayQuestion();
        } 
        else 
        {
            // End of questions logic
            Debug.Log("End of Category Questions");
        }
    }

    private void SetCategoryUIActive(bool isActive) 
     {
        foreach (Button btn in categoryButtons)
         {
            btn.gameObject.SetActive(isActive);
        }
    }

    private void setQuestionUIActive(bool isActive)
    {
        questionText.gameObject.SetActive(isActive);

        foreach (Button btn in replyButtons) 
        {
            btn.gameObject.SetActive(isActive);
        }
    }
}
   

   