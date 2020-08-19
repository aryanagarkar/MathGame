using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    public class SubtractionQuestion : Question
    {
        public SubtractionQuestion(string difficulty, string preferredDisplayType)
        {
            this.difficulty = difficulty;
            this.preferredDisplayType = preferredDisplayType;
        }

        override protected void createQuestion()
        {
            int num1 = 0;
            int num2 = 0;
            if (difficulty.Equals("easy"))
            {
                num1 = Random.Range(1, 20);
                num2 = Random.Range(1, 20);
            }
            if (difficulty.Equals("medium"))
            {
                num1 = Random.Range(1, 50);
                num2 = Random.Range(1, 50);
            }
            if (difficulty.Equals("hard"))
            {
                num1 = Random.Range(1, 100);
                num2 = Random.Range(1, 100);
            }

            problem = num1 + " - " + num2;
            answer = num1 - num2;
        }
    }
}
