// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Events;

// public class QuestionCanvas : MonoBehaviour
// {
//     [SerializeField]
//     InputField AnswerInput;

//     string answer;

//     void Start()
//     {
//         AnswerInput.gameObject.SetActive(true);
//         AnswerInput.GetComponent<InputField>().onEndEdit.AddListener(delegate { saveInput(); });
//     }

//     public void saveInput()
//     {
//         answer = AnswerInput.text;
//         if(answer.ToLower().Equals("yes")){
//             // Debug.Log(AnswerInput.gameObject.activeSelf);
//             AnswerInput.gameObject.SetActive(false);
//             //  Debug.Log(AnswerInput.gameObject.activeSelf);
//             Camera.main.GetComponent<GameController>().showNext();
//         }
//     }

//     public string Reply{
//         get{return answer;}
//     }
// }
