using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Import TextMeshPro
using UnityEngine.UI; // Import Unity UI
using UnityEngine.SceneManagement;
using System;

public class QuestionManager : MonoBehaviour {
    // Reference UI Elements
    public TMP_Text questionText, scoreText;    // Updated to TMP_Text
    public TMP_Text categoryTitle;  // Category Title TMP_Text
    public TMP_Text timerText, finalScoreText;    // Timer TMP_Text
    public Button[] replyButtons; // Array for reply buttons
    public Button exitButton;     // Exit button

    public GameObject gameOverPanel, correctPanel, incorrectPanel;

    List<Question> politicalquestionlist = new List<Question>();
    List<Question> civilquestionlist = new List<Question>();
    List<Question> economicquestionlist = new List<Question>();
    List<Question> socialquestionlist = new List<Question>();

    private int selectedQuestionsCategory; // Currently selected questions category
    private int currentQuestionIndex, tableSize;
    private int score;  // Player's score
    private float timer;  // Timer for question

    public TextAsset questioncsvfile;

    [System.Serializable]
    public struct Question {
        public int questionCategory; //Store category of questions (Political, Economic, Social and Civil)
        public string questionText;     //store questions.
        public string[] replies;        //Store replies.
        public int correctReplyIndex;    //Store correct replyindex.
        public string CorrectAnswer;
    }

    [System.Serializable]
    public class QuestionList {
        public Question[] question;

    }

    public QuestionList myQuestionList = new QuestionList();

    // Start is called before the first frame update
    void Start() {
        ReadCSV();
        InitializeGame();
    }

    void ReadCSV() {
        string[] data = questioncsvfile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        tableSize = data.Length / 8 - 1;
        myQuestionList.question = new Question[tableSize];

        for (int i = 0; i < tableSize; i++) {
            myQuestionList.question[i] = new Question();
            myQuestionList.question[i].questionCategory = int.Parse(data[8 * (i + 1)]);
            myQuestionList.question[i].questionText = data[8 * (i + 1) + 1];
            List<string> list = new List<string>(4);
            list.Add(data[8 * (i + 1) + 2]);
            list.Add(data[8 * (i + 1) + 3]);
            list.Add(data[8 * (i + 1) + 4]);
            list.Add(data[8 * (i + 1) + 5]);
            myQuestionList.question[i].replies = list.ToArray();
            myQuestionList.question[i].correctReplyIndex = int.Parse(data[8 * (i + 1) + 6]);
            myQuestionList.question[i].CorrectAnswer = data[8 * (i + 1) + 7];
        }

    }

    private void Update() {
        if (timerText.IsActive() == true) { UpdateTimerUI(); } else {
            Time.timeScale = 0;
            timer = 30f;
        }
    }

    private void InitializeGame() {
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
                selectedQuestionsCategory = 1;
                break;
            case "Civil":
                selectedQuestionsCategory = 2;
                break;
            case "Economic":
                selectedQuestionsCategory = 3;
                break;
            case "Social":
                selectedQuestionsCategory = 4;
                break;

            default:
                Debug.LogError("Invalid category selected: " + Category);
                return;
        }

        categoryTitle.text = Category + " Rights Questions"; // Update category title
        questionText.text = "This is a " + Category + " question here answewr";
        categoryTitle.text = Category + " Questions"; // Update category title
        SetQuestionUIActive(true);     // Show question UI
        currentQuestionIndex = 0;
        DisplayQuestion();

    }

    private void DisplayQuestion() {

        for (int i = 0; i < tableSize; i++) {
            if (myQuestionList.question[i].questionCategory == 1) {
                politicalquestionlist.Add(myQuestionList.question[i]);
            } else if (myQuestionList.question[i].questionCategory == 2) {
                civilquestionlist.Add(myQuestionList.question[i]);
            } else if (myQuestionList.question[i].questionCategory == 3) {
                economicquestionlist.Add(myQuestionList.question[i]);
            } else if (myQuestionList.question[i].questionCategory == 4) {
                socialquestionlist.Add(myQuestionList.question[i]);
            }
        }

        if (selectedQuestionsCategory == 1) {
            questionText.text = politicalquestionlist[currentQuestionIndex].questionText;
            for (int x = 0; x < replyButtons.Length; x++) {
                TMP_Text buttonText = replyButtons[x].GetComponentInChildren<TMP_Text>();
                buttonText.text = politicalquestionlist[currentQuestionIndex].replies[x];
                int replyIndex = x; // Capture the index for use in the lambda
                replyButtons[x].onClick.RemoveAllListeners();
                replyButtons[x].onClick.AddListener(() => CheckReply(replyIndex));
            }
        } else if (selectedQuestionsCategory == 2) {
            questionText.text = civilquestionlist[currentQuestionIndex].questionText;
            for (int x = 0; x < replyButtons.Length; x++) {
                TMP_Text buttonText = replyButtons[x].GetComponentInChildren<TMP_Text>();
                buttonText.text = civilquestionlist[currentQuestionIndex].replies[x];
                int replyIndex = x; // Capture the index for use in the lambda
                replyButtons[x].onClick.RemoveAllListeners();
                replyButtons[x].onClick.AddListener(() => CheckReply(replyIndex));
            }
        } else if (selectedQuestionsCategory == 3) {
            questionText.text = economicquestionlist[currentQuestionIndex].questionText;
            for (int x = 0; x < replyButtons.Length; x++) {
                TMP_Text buttonText = replyButtons[x].GetComponentInChildren<TMP_Text>();
                buttonText.text = economicquestionlist[currentQuestionIndex].replies[x];
                int replyIndex = x; // Capture the index for use in the lambda
                replyButtons[x].onClick.RemoveAllListeners();
                replyButtons[x].onClick.AddListener(() => CheckReply(replyIndex));
            }
        } else if (selectedQuestionsCategory == 4) {
            questionText.text = socialquestionlist[currentQuestionIndex].questionText;
            for (int x = 0; x < replyButtons.Length; x++) {
                TMP_Text buttonText = replyButtons[x].GetComponentInChildren<TMP_Text>();
                buttonText.text = socialquestionlist[currentQuestionIndex].replies[x];
                int replyIndex = x; // Capture the index for use in the lambda
                replyButtons[x].onClick.RemoveAllListeners();
                replyButtons[x].onClick.AddListener(() => CheckReply(replyIndex));
            }
        }
    }

    private void CheckReply(int replyIndex) {
        if (selectedQuestionsCategory == 1) {
            if (replyIndex == politicalquestionlist[currentQuestionIndex].correctReplyIndex) {
                // Correct answer logic
                score++;
                UpdateScoreUI();
                correctPanel.gameObject.SetActive(true);
            } else {
                // Incorrect answer logic
                incorrectPanel.gameObject.SetActive(true);
            }
        } else if (selectedQuestionsCategory == 2) {
            if (replyIndex == civilquestionlist[currentQuestionIndex].correctReplyIndex) {
                // Correct answer logic
                score++;
                UpdateScoreUI();
                correctPanel.gameObject.SetActive(true);

            } else {
                // Incorrect answer logic
                incorrectPanel.gameObject.SetActive(true);

            }
        } else if (selectedQuestionsCategory == 3) {
            if (replyIndex == economicquestionlist[currentQuestionIndex].correctReplyIndex) {
                // Correct answer logic
                score++;
                UpdateScoreUI();
                //incorrectui.gameobject.setActive;
                correctPanel.gameObject.SetActive(true);

            } else {
                // Incorrect answer logic
                //incorrectui.gameobject.setActive;
                incorrectPanel.gameObject.SetActive(true);

            }
        } else if (selectedQuestionsCategory == 4) {
            if (replyIndex == socialquestionlist[currentQuestionIndex].correctReplyIndex) {
                // Correct answer logic
                score++;
                UpdateScoreUI();
                //incorrectui.gameobject.setActive;
                correctPanel.gameObject.SetActive(true);

            } else {
                // Incorrect answer logic
                //incorrectui.gameobject.setActive;
                incorrectPanel.gameObject.SetActive(true);

            }
        }


        currentQuestionIndex++;
        if (currentQuestionIndex < tableSize) {
            DisplayQuestion();
        } else {
            EndGame();
        }
    }

    private void UpdateScoreUI() {
        scoreText.text = "Score: " + score;
        timer = 30f;
    }

    private void UpdateTimerUI() {
        //timerText.text = "Time: " + Mathf.Round(timer).ToString();

        Time.timeScale = 1;
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
        SceneManager.LoadScene("SampleScene"); // Example, assuming "MainMenu" is the name of your main menu scene
    }
}