using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rendering;

namespace Questions
{
    public class Subtraction : Addition
    {
        public Subtraction(int difficulty) : base(difficulty)
        {
            problem = string.Join(" - ", operands);
            answer = (int.Parse(operands[0]) - int.Parse(operands[1])).ToString();

            int error1 = 1;
            int error2 = 2;
            if(int.Parse(answer) - error1 < 0){
                wrongAnswers[0] = (int.Parse(answer) + error1).ToString();
            }
            wrongAnswers[1] = (int.Parse(answer) + error2).ToString();
        }
    }
}