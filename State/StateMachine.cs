using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;
using events;

public class StateMachine
{
    History hist;

    public StateMachine(History history)
    {
        this.hist = history;
    }


    public History CurrentHistory
    {
        get { return hist; }
    }

    public State processEvent(EventTypes ev)
    {
        State state = null;
        if (ev == EventTypes.rightAnswerEvent)
        {
            state = getNextStateForRightAnswer();
        }
        if (ev == EventTypes.wrongAnswerEvent)
        {
            state = getNextStateForWrongAnswer();
        }
        hist.push(state);
        return state;
    }

    private State getNextStateForRightAnswer()
    {
        State state = hist.peek();
        int difficulty = state.Difficulty;
        int maxDifficulty = state.Topic.MaxDifficulty;
        State newState = null;

        if (difficulty < maxDifficulty)
        {
            newState = new State(state.Grade, state.Journey, state.Topic, difficulty + 1, DisplayTypeEnum.circleDisplay);
        }
        if(difficulty == maxDifficulty){
            newState = state;
        }
        return newState;
    }

    private State getNextStateForWrongAnswer()
    {
        State state = hist.peek();
        int difficulty = state.Difficulty;
        int maxDifficulty = state.Topic.MaxDifficulty;
        State newState = null;

        if (difficulty != 1)
        {
            newState = new State(state.Grade, state.Journey, state.Topic, difficulty - 1, DisplayTypeEnum.circleDisplay);
        }
        else
        {
            newState = state;
        }
        return newState;
    }
}
