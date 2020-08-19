using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Questions;

namespace Tests
{
    public class AdditionQuestionTest
    {
        [Test]
        public void createQuestionTest()
        {
            AdditionQuestion question = new AdditionQuestion("easy", "circle");
            question.setProblemAndAnswer();
            string problem = question.Problem;

            int blankIndex = problem.IndexOf(" ");
            int secondBlankIndex = problem.IndexOf("+", blankIndex); 

            string num1 = problem.Substring(0, blankIndex + 1);
            string num2 = problem.Substring(secondBlankIndex + 1); 

            Assert.IsTrue(int.Parse(num1) < 20);  
            Assert.IsTrue(int.Parse(num2) < 20);
            Assert.AreEqual(problem, num1 + "+" + num2);        
        }
    }
}
