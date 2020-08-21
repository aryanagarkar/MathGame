using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    abstract public class Question
    {

        protected string difficulty;
        protected string preferredDisplayType;
        protected string[] operands;
        protected string answer;
        protected string problem;
        protected string[] wrongAnswers;

        public Question(string difficulty)
        {
            this.difficulty = difficulty;
        }

        public string Difficulty
        {
            get
            {
                return difficulty;
            }
        }

        public string Problem
        {
            get
            {
                return problem;
            }
        }

        public string Answer
        {
            get
            {
                return answer;
            }
        }

        public string PreferredDisplayType
        {
            get
            {
                return preferredDisplayType;
            }
        }

        public string[] Operands
        {
            get
            {
                return operands;
            }
        }

        public string[] WrongAnswers
        {
            get
            {
                return wrongAnswers;
            }
        }
    }
}
