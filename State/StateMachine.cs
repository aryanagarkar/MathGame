using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;
using events;

public class StateMachine
{
    State state;
    History hist;

    public StateMachine()
    {
        ArrayList topics = new ArrayList();
        Topic topic1 = new Topic(5, "addition");
        Topic topic2 = new Topic(5, "subtraction");
        topics.Add(topic1);
        topics.Add(topic2);
        ArrayList journeys = new ArrayList();
        Journey journey1 = new Journey(topics);
        journeys.Add(journey1);
        Grade grade1 = new Grade(journeys);

        state = new State(grade1, journey1, topic1, 5);
        hist = new History();
        hist.push(state);
    }

    public State CurrentState
    {
        get { return state; }
        set { state = value; }
    }

    public History CurrentHistory{
        get { return hist; }
        set { hist = value; }
    }

    public State getNextState(EventTypes ev)
    {
        if (ev == EventTypes.rightAnswerEvent)
        {
            return getNextLevelForRightAnswer();
        }
        if (ev == EventTypes.wrongAnswerEvent)
        {
            return getNextLevelForWrongAnswer();
        }
        return null;
    }

    private State getNextLevelForRightAnswer()
    {
        int difficulty = state.Difficulty;
        int maxDifficulty = state.Topic.MaxDifficulty;

        if (difficulty < maxDifficulty)
        {
            State newState = new State(state.Grade, state.Journey, state.Topic, difficulty + 1);
            state = newState;
            hist.push(newState);
            return newState;
        }
        else
        {
            return state;
        }
    }

    private State getNextLevelForWrongAnswer()
    {
        int difficulty = state.Difficulty;
        int maxDifficulty = state.Topic.MaxDifficulty;

        if (difficulty != 1)
        {
            State newState = new State(state.Grade, state.Journey, state.Topic, difficulty - 1);
            state = newState;
            hist.push(newState);
            return newState;
        }
        else
        {
            return state;
        }
    }
}
