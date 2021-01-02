using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;
using events;
using Story;

namespace state
{
    public class StateMachine
    {
        const string path = "/home/arya/Workspace/GameSerializedFiles/SampleStoryGraph.json";
        const int STARTLEVEL = 1;

        History hist;

        Graph story;

        public StateMachine(History history)
        {
            story = SaveAndLoadStory.loadStory(path);
            this.hist = history;
        }

        public StateMachine()
        {
            story = SaveAndLoadStory.loadStory(path);
            GraphNode startNode = story.Nodes[0];
            List<Topic> topics = new List<Topic>();
            Topic topic1 = new Topic(3, QuestionTypeEnum.addition);
            Topic topic2 = new Topic(3, QuestionTypeEnum.subtraction);
            Topic topic3 = new Topic(3, QuestionTypeEnum.multiplication);
            Topic topic4 = new Topic(3, QuestionTypeEnum.division);
            topics.Add(topic1);
            topics.Add(topic2);
            topics.Add(topic3);
            topics.Add(topic4);
            Journey journey = new Journey(topics);
            List<Journey> journeys = new List<Journey>();
            journeys.Add(journey);
            Grade grade = new Grade(journeys);
            this.hist = new History();
            State startState = new State(startNode, grade, journey, topic1, STARTLEVEL);
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
                newState = new State(state.CurrentNode, state.Grade, state.Journey, state.Topic, difficulty + 1);
            }
            if (difficulty == maxDifficulty)
            {
                GraphNode nextNode = getNextStoryNode(state.CurrentNode);
                Topic next = state.Journey.getNextTopic(state.Topic);
                newState = new State(nextNode, state.Grade, state.Journey, next, STARTLEVEL);
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
                newState = new State(state.CurrentNode, state.Grade, state.Journey, state.Topic, difficulty - 1);
            }
            else
            {
                newState = new State(state.CurrentNode, state.Grade, state.Journey, state.Topic, STARTLEVEL);
            }
            return newState;
        }

        private GraphNode getNextStoryNode(GraphNode current){
            int currIndex = story.Nodes.IndexOf(current);
            if(currIndex == story.Nodes.Count - 1){
                return current;
            }
            int nextIndex = currIndex + 1;
            return story.Nodes[nextIndex];
        }
    }
}
