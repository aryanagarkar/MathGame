using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    public class Addition : Question
    {
        public Addition(string difficulty) : base(difficulty)
        {
            operands = createOperands(difficulty);

            problem = string.Join(" + ", operands);
            answer = (int.Parse(operands[0]) + int.Parse(operands[1])).ToString();

            wrongAnswers = new string[2];
            int error = 2;
            wrongAnswers[0] = (int.Parse(answer) - error).ToString();
            wrongAnswers[1] = (int.Parse(answer) + error).ToString();

            preferredDisplayType = "CircleDisplay";
        }

        private static string[] createOperands(string difficulty)
        {
            int len = getNumOperandsForDifficulty(difficulty);
            string[] operands = new string[len];

            if (difficulty.Equals("easy"))
            {
                for (int i = 0; i < len; i++)
                {
                    operands[i] = Random.Range(1, 20).ToString();
                }
            }
            if (difficulty.Equals("medium"))
            {
                for (int j = 0; j < len; j++)
                {
                    operands[j] = Random.Range(21, 50).ToString();
                }
            }
            if (difficulty.Equals("hard"))
            {
                for (int k = 0; k < len; k++)
                {
                    operands[k] = Random.Range(51, 100).ToString();
                }
            }
            return operands;
        }

        private static int getNumOperandsForDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "easy":
                    return 2;
                case "medium":
                    return 2;
                case "hard":
                    return 2;
                default:
                    return 2;
            }
        }
    }
}
