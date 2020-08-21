using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Linq;
using Questions;

namespace Tests
{
    public class AdditionQuestionTest
    {
        [Test]
        public void testProblemOperandsAreReasonable()
        {
            for(int i = 0; i < 100; i++){
                Addition question = new Addition("easy");
                string[] operands = question.Operands;

                int operand1 = int.Parse(operands[0]);
                int operand2 = int.Parse(operands[1]);

                Assert.IsTrue(operand1 < 20);
                Assert.IsTrue(operand2 < 20);
            }
        }

        [Test]
        public void testWrongAnswersHaveNoDuplicates(){
            Addition question = new Addition("easy");
            string[] wrongAnswers = question.WrongAnswers;
             
            Assert.IsTrue(Array.IndexOf(wrongAnswers, question.Answer) == -1);
            Assert.IsTrue(wrongAnswers.Length == wrongAnswers.Distinct().Count());
        }
    }
}
