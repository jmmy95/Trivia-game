using UnityEngine;

[CreateAssetMenu(fileName = "New QuestionData", menuName = "QuestionData")]
public class QuestionsData : ScriptableObject
{
    [System.Serializable]

    public struct Question
    {
        public string questionText;//store questions.
        public string[] replies;//Store replies.
        public int correctReplyIndex;//Store correct replyindex.
    }

    public Question[] questions;//hold collection of questions and their associated data.
    
}
