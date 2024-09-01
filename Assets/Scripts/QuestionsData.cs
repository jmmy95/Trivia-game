using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionData", menuName = "QuestionData")]
public class QuestionsData : ScriptableObject
{
    public enum category
    {
        Political_Rights,
        Civil_Rights,
        Economic_Rights,
        Social_Rights
    }

    [System.Serializable]

    public struct Question
    {
        public string questionText;     //store questions.
        public string[] replies;        //Store replies.
        public int correctReplyIndex;    //Store correct replyindex.
        public category questionCategory;  //Store category of questions (Political, Economic, Social and Civil)
    }

    public Question[] questions;//hold collection of questions and their associated data.


}