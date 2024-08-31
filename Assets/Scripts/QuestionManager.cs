using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
public class QuestionManager : MonoBehaviour {
    //trying to work on the correct and incorrect sounds
    // public AudioSource answerSound;

    // public AudioClip correctSound;

    // public AudioClip incorrectSound;
    //
    public Text questionText;
    public Text scoreText;
    public Text timeScore;
    public Text FinalScore;
=======
=======
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 29566f8c9985c0ef86c1a88c1e4292a98d1d00a5
public class QuestionManager : MonoBehaviour
 {
    public TextMeshProUGUI questionText, scoreText, timeScore, FinalScore;
  
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 2e14b2abb6a43f5655ab685193d0bd4ae3ecaa66
=======
>>>>>>> 29566f8c9985c0ef86c1a88c1e4292a98d1d00a5
    public Button[] replyButtons;
    public Button[] categoryButtons;  // The buttons for the categories

    // References to ScriptableObjects for each category
    public QuestionsData politicalQuestionsCategory;
    public QuestionsData civilQuestionsCategory;
    public QuestionsData economicQuestionsCategory;
    public QuestionsData socialQuestionsCategory;

    public GameObject Right;  // Reference to the "CORRECT" Text GameObject
    public GameObject Wrong;  // Reference to the "INCORRECT" Text GameObject
    public GameObject GameOver;

    private QuestionsData selectedQuestions; // To hold the currently active category
    private int currentQuestionIndex;

    private void Start() {
        // Hide the question and reply UI initially
        setQuestionUIActive(false);
        SetCategoryUIActive(true); // Show categories initially
        Right.gameObject.SetActive(false);
        Wrong.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);

        //checking to see if the coorect sound plays at start
    //      if (answerSound != null && correctSound != null) {
    //     answerSound.PlayOneShot(correctSound); // This should play the correct sound on start
    // }
    }

    public void OnCategorySelected(string Category) {
        // Determine which category was selected
        switch (Category) {
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
            default:
                Debug.LogError("Invalid category selected: " + Category);
                return;
        }

        if (selectedQuestions != null && selectedQuestions.questions.Length > 0) {
            // Hide category buttons and show the first question from the selected category
            SetCategoryUIActive(false);
            setQuestionUIActive(true);
            currentQuestionIndex = 0;
            DisplayQuestion();
        } else {
            Debug.LogError("No questions available for the selected category: " + Category);
        }
    }

    private void DisplayQuestion() 
    {
        if (selectedQuestions != null && currentQuestionIndex < selectedQuestions.questions.Length) 
        {
            questionText.text = selectedQuestions.questions[currentQuestionIndex].questionText;
            Debug.Log("Displaying Question: " + questionText.text); // Log the question

            for (int i = 0; i < replyButtons.Length; i++) {
                string reply = selectedQuestions.questions[currentQuestionIndex].replies[i];
                Debug.Log("Displaying Reply: " + reply); // Log each reply

                replyButtons[i].GetComponentInChildren<Text>().text = reply;
                int replyIndex = i; // Capture the index for use in the lambda
                replyButtons[i].onClick.RemoveAllListeners();
                replyButtons[i].onClick.AddListener(() => CheckReply(replyIndex));
            }
        }
    }

    public void CheckReply(int replyIndex) {
        if (selectedQuestions != null && replyIndex < selectedQuestions.questions.Length) {
            if (replyIndex == selectedQuestions.questions[currentQuestionIndex].correctReplyIndex) {
                //play correct sound
                // answerSound.PlayOneShot(correctSound);
                
                // Correct answer logic
                Debug.Log("Correct!");

            
                // Show the "CORRECT" UI
                Right.SetActive(true);
                Wrong.SetActive(false);
            } else {
                //play incorrect sound
                // answerSound.PlayOneShot(incorrectSound);

                // Incorrect answer logic
                Debug.Log("Incorrect!");

                // Show the "INCORRECT" UI
                Right.SetActive(false);
                Wrong.SetActive(true);
            }

            // Hide the "CORRECT" or "INCORRECT" UI after a delay
            StartCoroutine(HideFeedback());

            // Move to the next question
            currentQuestionIndex++;

            if (currentQuestionIndex < selectedQuestions.questions.Length) {
                DisplayQuestion();
            } else {
                // End of questions logic
                Debug.Log("End of Category Questions");
            }
        } else {
            Debug.LogError("SelectedQuestions is null or invalid reply index.");
        }
    }

    // Add a coroutine to hide feedback after a short delay
    private IEnumerator HideFeedback() {
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        Right.SetActive(false);
        Wrong.SetActive(false);
    }

    private void SetCategoryUIActive(bool isActive) {
        foreach (Button btn in categoryButtons) {
            if (btn != null) {
                btn.gameObject.SetActive(isActive);
            }
        }
    }


    private void setQuestionUIActive(bool isActive) {
        if (questionText != null) {
            questionText.gameObject.SetActive(isActive);
        }

        foreach (Button btn in replyButtons) {
            if (btn != null) {
                btn.gameObject.SetActive(isActive);
            }
        }
    }
}