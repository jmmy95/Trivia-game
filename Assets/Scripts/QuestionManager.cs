using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Import TextMeshPro
using UnityEngine.UI; // Import Unity UI
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour {
    // Reference UI Elements
    public TMP_Text questionText; // Updated to TMP_Text
    public TMP_Text scoreText;    // Updated to TMP_Text
    public TMP_Text categoryTitle;  // Category Title TMP_Text
    public TMP_Text timerText, finalScoreText;    // Timer TMP_Text
    public Button[] replyButtons; // Array for reply buttons
    public Button exitButton;     // Exit button
    public GameObject gameOverPanel;

    // Other variables and references
    public QuestionsData politicalQuestionsCategory;
    public QuestionsData civilQuestionsCategory;
    public QuestionsData economicQuestionsCategory;
    public QuestionsData socialQuestionsCategory;

    private QuestionsData selectedQuestions; // Currently selected questions category
    private int currentQuestionIndex;
    private int score;  // Player's score
    private float timer;  // Timer for question

    private void Start() {
        // Initialize UI and game logic
        InitializeGame();
        //currentTime = 100f;
    }

    private void Update() {
        if (timerText.IsActive() == true) { UpdateTimerUI(); }
    }

    private void InitializeGame() {
        // Hide UI elements initially
        //SetQuestionUIActive(false);
        score = 0;  // Initialize score
        UpdateScoreUI();
        timer = 30f;  // Example timer value, can be changed



        // Setup exit button functionality
        exitButton.onClick.AddListener(ExitGame);
    }

    public void OnCategorySelected(string Category) {
        // Logic to handle category selection
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

        categoryTitle.text = Category; // Update category title
        questionText.text = "This is a " + Category + " question here answewr";


        if (selectedQuestions != null && selectedQuestions.questions.Length > 0) {
            categoryTitle.text = Category; // Update category title
            SetQuestionUIActive(true);     // Show question UI
            currentQuestionIndex = 0;
            DisplayQuestion();
        } else {
            Debug.LogError("No questions available for the selected category: " + Category);
        }
    }

    private void DisplayQuestion() {
        if (selectedQuestions != null && currentQuestionIndex < selectedQuestions.questions.Length) {
            questionText.text = selectedQuestions.questions[currentQuestionIndex].questionText;

            for (int i = 0; i < replyButtons.Length; i++) {
                TMP_Text buttonText = replyButtons[i].GetComponentInChildren<TMP_Text>();
                buttonText.text = selectedQuestions.questions[currentQuestionIndex].replies[i];
                int replyIndex = i; // Capture the index for use in the lambda
                replyButtons[i].onClick.RemoveAllListeners();
                replyButtons[i].onClick.AddListener(() => CheckReply(replyIndex));
            }
        }
    }

    private void CheckReply(int replyIndex) {
        if (replyIndex == selectedQuestions.questions[currentQuestionIndex].correctReplyIndex) {
            // Correct answer logic
            score++;
            UpdateScoreUI();
        } else {
            // Incorrect answer logic
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < selectedQuestions.questions.Length) {
            DisplayQuestion();
        } else {
            EndGame();
        }
    }

    private void UpdateScoreUI() {
        scoreText.text = "Score: " + score;
    }

    private void UpdateTimerUI() {
        //timerText.text = "Time: " + Mathf.Round(timer).ToString();

        timer -= 1 * Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("0");

        if (timer <= 0 || timerText.text == "0") {
            timerText.text = "0";
            gameOverPanel.SetActive(true);
            finalScoreText.text = "You scored: " + score;

        }
    }

    private void SetQuestionUIActive(bool isActive) {
        questionText.gameObject.SetActive(isActive);
        foreach (Button btn in replyButtons) {
            btn.gameObject.SetActive(isActive);
        }
    }

    private void EndGame() {
        // Logic to handle end of the game
    }

    private void ExitGame() {
        // Logic to exit the game or return to main menu
        SceneManager.LoadScene("MainMenu"); // Example, assuming "MainMenu" is the name of your main menu scene
    }
}