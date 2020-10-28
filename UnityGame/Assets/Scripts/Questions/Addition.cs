using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Renderers;

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

            preferredDisplayType = DisplayTypeEnum.circleDisplay;
        }

        private static string[] createOperands(int difficulty)
        {
            int len = getNumOperandsForDifficulty(difficulty);
            int min;
            int max;
            string[] operands = new string[len];

            switch (difficulty)
            {
                case 1:
                    min = 1;
                    max = 10;
                    break;

                case 2:
                    min = 11;
                    max = 20;
                    break;
                case 3:
                    min = 21;
                    max = 30;
                    break;
                case 4:
                    min = 31;
                    max = 40;
                    break;
                case 5:
                    min = 41;
                    max = 50;
                    break;
                default:
                    min = 1;
                    max = 10;
                    break;
            }

            for (int i = 0; i < len; i++)
            {
                operands[i] = Random.Range(min, max).ToString();
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
                case 4:
                    return 2;
                case 5:
                    return 2;
                default:
                    return 2;
            }
        }
    }
}
