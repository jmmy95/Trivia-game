using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class csvReader : MonoBehaviour
{
    public TextAsset questioncsvfile;

    [System.Serializable]
    public struct Question
    {
        public int questionCategory; //Store category of questions (Political, Economic, Social and Civil)
        public string questionText;     //store questions.
        public string[] replies;        //Store replies.
        public int correctReplyIndex;    //Store correct replyindex.
        public string CorrectAnswer;
    }    

    [System.Serializable]
    public class QuestionList
    {
        public Question[] question;

    }

    public QuestionList myQuestionList = new QuestionList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = questioncsvfile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 8 - 1;
        myQuestionList.question = new Question[tableSize];

        for (int i =0; i < tableSize; i++)
        {
            myQuestionList.question[i] = new Question();
            myQuestionList.question[i].questionCategory = int.Parse(data[8 * (i + 1)]);
            myQuestionList.question[i].questionText = data[8 * (i + 1) + 1];
            List<string> list = new List<string>();
            list.Add(data[8 * (i + 1) + 2]);
            list.Add(data[8 * (i + 1) + 3]);
            list.Add(data[8 * (i + 1) + 4]);
            list.Add(data[8 * (i + 1) + 5]);
            myQuestionList.question[i].replies = list.ToArray();
            myQuestionList.question[i].correctReplyIndex = int.Parse(data[8 * (i + 1) + 6]);
            myQuestionList.question[i].CorrectAnswer = data[8 * (i + 1) + 7];
        }

    }


}
