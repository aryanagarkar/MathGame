using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Questions
{
    public class Division : Addition
    {
        public Division(int difficulty) : base(difficulty)
        {
            problem = string.Join(" / ", operands);
            answer = (int.Parse(operands[0]) / int.Parse(operands[1])).ToString();
        }
    }
}
