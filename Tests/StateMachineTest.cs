using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using events;

namespace Tests
{
    public class StateMachineTest
    {
        [Test]
        public void testGetNextStateForRightAnswer()
        {
            StateMachine stateMachine = new StateMachine();

            ArrayList topics = new ArrayList();
            Topic topic1 = new Topic(5, "addition");
            topics.Add(topic1);
            ArrayList journeys = new ArrayList();
            Journey journey1 = new Journey(topics);
            journeys.Add(journey1);
            Grade grade1 = new Grade(journeys);

            State state = new State(grade1, journey1, topic1, 2);
            stateMachine.CurrentState = state;
            State actualState = stateMachine.getNextState(EventTypes.rightAnswerEvent);
            State expectedState = new State(grade1, journey1, topic1, 3);
            Assert.IsTrue(actualState.isEqual(expectedState));
        }

        [Test]
        public void testGetNextStateForWrongAnswer(){
            StateMachine stateMachine = new StateMachine();

            ArrayList topics = new ArrayList();
            Topic topic1 = new Topic(5, "addition");
            topics.Add(topic1);
            ArrayList journeys = new ArrayList();
            Journey journey1 = new Journey(topics);
            journeys.Add(journey1);
            Grade grade1 = new Grade(journeys);

            State state = new State(grade1, journey1, topic1, 5);
            stateMachine.CurrentState = state;
            State actualState = stateMachine.getNextState(EventTypes.wrongAnswerEvent);
            State expectedState = new State(grade1, journey1, topic1, 4);
            Assert.IsTrue(actualState.isEqual(expectedState));
        }
    }
}
