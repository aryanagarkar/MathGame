using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    abstract public class Question : MonoBehaviour
    {
        protected string difficulty;
        protected string preferredDisplayType;

        protected int answer;
        protected string problem;

        string[] possibleAnswers;


        public string Difficulty
        {
            get { return difficulty; }
        }
        public string Problem
        {
            get { return problem; }
        }

        public int Answer
        {
            get { return answer; }
        }

        public string[] PossibleAnswers
        {
            get
            {
                possibleAnswers = new string[2];
                int error = 2;
                possibleAnswers[0] = (answer - error).ToString();
                possibleAnswers[1] = (answer + error).ToString();
                return possibleAnswers;
            }
        }

        protected abstract void createQuestion();

        public void setProblemAndAnswer()
        {
            createQuestion();
        }
    }
}
