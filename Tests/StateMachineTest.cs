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
        public void testDifficultyIncreasesForLowDifficulty_rightAnswer()
        {
            State state = createStateFor(4);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            Assert.IsTrue(stateMachine.processEvent(EventTypes.rightAnswerEvent).
            isEqual(new State(state.Grade, state.Journey, state.Topic, 5, DisplayTypeEnum.circleDisplay)));
        }


        [Test]
        public void testNoChangeInDifficultyAtMaxDifficulty_rightAnswer()
        {
            State state = createStateFor(5);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            Assert.IsTrue(stateMachine.processEvent(EventTypes.rightAnswerEvent).
            isEqual(new State(state.Grade, state.Journey, state.Topic, 5, DisplayTypeEnum.circleDisplay)));
        }

        [Test]
        public void testDifficultyDecreasesForDifficultyGreaterThanOne_wrongAnswer()
        {
            State state = createStateFor(2);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            Assert.IsTrue(stateMachine.processEvent(EventTypes.wrongAnswerEvent).
            isEqual(new State(state.Grade, state.Journey, state.Topic, 1, DisplayTypeEnum.circleDisplay)));
        }

        [Test]
        public void testNoChangeInDifficultyForAtMinDifficulty_wrongAnswer()
        {
            State state = createStateFor(1);
            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            Assert.IsTrue(stateMachine.processEvent(EventTypes.wrongAnswerEvent).
            isEqual(new State(state.Grade, state.Journey, state.Topic, 1, DisplayTypeEnum.circleDisplay)));
        }

        private State createStateFor(int difficulty)
        {
            ArrayList topics = new ArrayList();
            Topic topic = new Topic(difficulty, "addition");
            topics.Add(topic);
            ArrayList journeys = new ArrayList();
            Journey journey = new Journey(topics);
            journeys.Add(journey);
            Grade grade = new Grade(journeys);

            return new State(grade, journey, topic, difficulty, DisplayTypeEnum.circleDisplay);
        }
    }
}
