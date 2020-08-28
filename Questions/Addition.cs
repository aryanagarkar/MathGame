using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    public class Addition : Question
    {
        public Addition(int difficulty) : base(difficulty)
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

        private static string[] createOperands(int difficulty)
        {
            int len = getNumOperandsForDifficulty(difficulty);
            string[] operands = new string[len];

            if (difficulty.Equals(1))
            {
                for (int i = 0; i < len; i++)
                {
                    operands[i] = Random.Range(1, 10).ToString();
                }
            }
            if (difficulty.Equals(2))
            {
                for (int j = 0; j < len; j++)
                {
                    operands[j] = Random.Range(11, 20).ToString();
                }
            }
            if (difficulty.Equals(3))
            {
                for (int k = 0; k < len; k++)
                {
                    operands[k] = Random.Range(21, 30).ToString();
                }
            }
             if (difficulty.Equals(4))
            {
                for (int l = 0; l < len; l++)
                {
                    operands[l] = Random.Range(31, 40).ToString();
                }
            }
             if (difficulty.Equals(5))
            {
                for (int m = 0; m < len; m++)
                {
                    operands[m] = Random.Range(41, 50).ToString();
                }
            }
            return operands;
        }

        private static int getNumOperandsForDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    return 2;
                case 2:
                    return 2;
                case 3:
                    return 2;
                default:
                    return 2;
            }
        }
    }
}
