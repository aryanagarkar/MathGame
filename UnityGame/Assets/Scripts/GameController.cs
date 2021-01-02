using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Questions;
using events;
using state;
using Gamedata;
using Rendering;
using Story;

public class GameController : MonoBehaviour
{
    StateMachine stateMachine;

    [SerializeField]
    GameObject prefabGoodJobScreen;

    void Start()
    {
        GameData data = SaveAndLoadSystem.loadData();

        if(data.history.Empty){
            stateMachine = new StateMachine();
        }
        else{
            stateMachine = new StateMachine(data.history);
        }

        Question question = Factory.createQuestion(stateMachine.CurrentState);
        Camera.main.GetComponent<Renderers>().displayUsingCorrectRenderer(
            question, stateMachine.CurrentState.CurrentNode.Element);
    }

    public void rightAnswerEvent(){
        State newState = stateMachine.processEvent(EventTypeEnum.rightAnswerEvent);
        Question newQuestion = Factory.createQuestion(newState);
        destroyAllObjects();
        Camera.main.GetComponent<Renderers>().displayUsingCorrectRenderer(
            newQuestion, newState.CurrentNode.Element);
    }

    public void wrongAnswerEvent(){
        State newState = stateMachine.processEvent(EventTypeEnum.wrongAnswerEvent);
        Question newQuestion = Factory.createQuestion(newState);
        destroyAllObjects();
        Camera.main.GetComponent<Renderers>().displayUsingCorrectRenderer(
             newQuestion, newState.CurrentNode.Element);
    }

    private void destroyAllObjects(){
        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
        foreach(GameObject gameobject in circles){
            Destroy(gameobject);
        }
        GameObject questioncanvas = GameObject.FindGameObjectWithTag("QuestionCanvas");
        Destroy(questioncanvas);
    }
}