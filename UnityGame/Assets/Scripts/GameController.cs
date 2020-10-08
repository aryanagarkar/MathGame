﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Questions;
using events;

public class GameController : MonoBehaviour
{
    StateMachine stateMachine;

    void Start()
    {
        History loadedHistory = SaveAndLoadSystem.loadData();
        stateMachine = new StateMachine(loadedHistory);

        Question question = Factory.createQuestion(stateMachine.CurrentState);
        Camera.main.GetComponent<CircleDisplayRenderer>().display(question);
    }

    void Update()
    {
        
    }

    public void rightAnswerEvent(){
        State newState = stateMachine.processEvent(EventTypeEnum.rightAnswerEvent);
        Question newQuestion = Factory.createQuestion(newState);
        destroyAllObjects();
        Camera.main.GetComponent<CircleDisplayRenderer>().display(newQuestion);
    }

    public void wrongAnswerEvent(){
        State newState = stateMachine.processEvent(EventTypeEnum.wrongAnswerEvent);
        Question newQuestion = Factory.createQuestion(newState);
        destroyAllObjects();
        Camera.main.GetComponent<CircleDisplayRenderer>().display(newQuestion);
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