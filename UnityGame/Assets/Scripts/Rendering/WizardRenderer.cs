using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Questions;
using Story;

namespace Rendering
{
    public class WizardRenderer : MonoBehaviour
    {
        [SerializeField]
        GameObject prefabQuestionDisplay;

        [SerializeField]
        GameObject prefabCircle;

        public void display(Question question, StoryElement element)
        {
            GameObject questionCanvas = Instantiate(prefabQuestionDisplay);
            questionCanvas.transform.GetChild(0).GetComponent<Text>().text = element.Conversations[0] + " " + question.Problem;
            questionCanvas.transform.GetChild(0).GetComponent<Text>().fontSize = 15;

            GameObject circle1 = Instantiate(prefabCircle);
            circle1.transform.position = new Vector3(0, 0, 0);
            circle1.transform.GetChild(0).GetComponent<TextMesh>().text = question.WrongAnswers[0];
            circle1.GetComponent<Circle>().Right = false;

            GameObject circle2 = Instantiate(prefabCircle);
            circle2.transform.position = new Vector3(5, 0, 0);
            circle2.transform.GetChild(0).GetComponent<TextMesh>().text = question.Answer;
            circle2.GetComponent<Circle>().Right = true;

            GameObject circle3 = Instantiate(prefabCircle);
            circle3.transform.position = new Vector3(-5, 0, 0);
            circle3.transform.GetChild(0).GetComponent<TextMesh>().text = question.WrongAnswers[1];
            circle3.GetComponent<Circle>().Right = false;
        }
    }
}
