using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;


[System.Serializable]
public class Topic
{
    int maxDifficulty;
    QuestionTypeEnum questionType;

    public Topic(int maxDifficulty, QuestionTypeEnum questionType)
    {
        this.maxDifficulty = maxDifficulty;
        this.questionType = questionType;
    }

    public int MaxDifficulty
    {
        get { return maxDifficulty; }
    }

    public string QuestionType
    {
        get { return questionType.ToString(); }
    }
}

