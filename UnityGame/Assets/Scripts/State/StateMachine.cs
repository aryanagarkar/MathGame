﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;
using events;

namespace state
{
    public class StateMachine
    {
        History hist;

        public StateMachine(History history)
        {
            this.hist = history;
        }

        public StateMachine()
        {
            this.hist = new History();
            Topic startTopic = new Topic(5, QuestionTypeEnum.addition);
            State startState = new State(startTopic, 2);
            hist.push(startState);
        }


        public History CurrentHistory
        {
            get { return hist; }
        }

        public State CurrentState
        {
            get { return hist.peek(); }
        }

        public State processEvent(EventTypeEnum ev)
        {
            State state = null;
            if (ev == EventTypeEnum.rightAnswerEvent)
            {
                state = getNextStateForRightAnswer();
            }
            if (ev == EventTypeEnum.wrongAnswerEvent)
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
                newState = new State(state.Topic, difficulty + 1);
            }
            if (difficulty == maxDifficulty)
            {
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
                newState = new State(state.Topic, difficulty - 1);
            }
            else
            {
                newState = state;
            }
            return newState;
        }
    }
}
