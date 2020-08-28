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
    public class AdditionTest
    {
        [Test]
        public void testProblemOperandsAreReasonable()
        {
            for(int i = 0; i < 100; i++){
                Addition question = new Addition(1);
                string[] operands = question.Operands;

                for(int j = 0; j < operands.Length - 1; j++){
                    Assert.IsTrue(int.Parse(operands[j]) < 20);
                }
            }
        }

        [Test]
        public void testWrongAnswersHaveNoDuplicates(){
            Addition question = new Addition(1);
            string[] wrongAnswers = question.WrongAnswers;
             
            Assert.IsTrue(Array.IndexOf(wrongAnswers, question.Answer) == -1);
            Assert.IsTrue(wrongAnswers.Length == wrongAnswers.Distinct().Count());
        }
    }
}
