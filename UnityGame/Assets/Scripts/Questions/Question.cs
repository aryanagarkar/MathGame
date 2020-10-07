using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    public class Question
    {
        protected int difficulty;
        protected string[] displayTypes;
        protected DisplayTypeEnum preferredDisplayType;
        protected string[] operands;
        protected string answer;
        protected string problem;
        protected string[] wrongAnswers;

        public Question(int difficulty)
        {
            this.difficulty = difficulty;
        }

        public int Difficulty
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

        public string[] DisplayTypes
        {
            get
            {
                return displayTypes;
            }
        }

        public DisplayTypeEnum PreferredDisplayType
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
