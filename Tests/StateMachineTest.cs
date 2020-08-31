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

        private static readonly int MAX_TOPIC_DIFFICULTY = 5;

        [Test]
        public void testDifficultyIncrementsForLowDifficulty_rightAnswer()
        {
            // Setup
            int difficulty = 2;
            State state = createStateFor(difficulty);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            // Test
            State newState = stateMachine.processEvent(EventTypes.rightAnswerEvent);

            // Assertions
            State expected = new State(state.Grade, state.Journey, state.Topic, difficulty + 1, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }


        [Test]
        public void testNoChangeInDifficultyAtMaxDifficulty_rightAnswer()
        {
            // Setup
            int difficulty = 5;
            State state = createStateFor(difficulty);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            // Test
            State newState = stateMachine.processEvent(EventTypes.rightAnswerEvent);

            // Assertions
            State expected = new State(state.Grade, state.Journey, state.Topic, difficulty, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }

        [Test]
        public void testDifficultyDecreasesForDifficultyGreaterThanOne_wrongAnswer()
        {
            // Setup
            int difficulty = 2;
            State state = createStateFor(difficulty);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            // Test
            State newState = stateMachine.processEvent(EventTypes.wrongAnswerEvent);

            // Assertions
            State expected = new State(state.Grade, state.Journey, state.Topic, difficulty - 1, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }

        [Test]
        public void testNoChangeInDifficultyForAtMinDifficulty_wrongAnswer()
        {
            // Setup
            int difficulty = 1;
            State state = createStateFor(difficulty);

            History history = new History();
            history.push(state);

            StateMachine stateMachine = new StateMachine(history);

            // Test
            State newState = stateMachine.processEvent(EventTypes.wrongAnswerEvent);

            // Assertions
            State expected = new State(state.Grade, state.Journey, state.Topic, difficulty, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }

        private State createStateFor(int difficulty)
        {
            ArrayList topics = new ArrayList();
            Topic topic = new Topic(MAX_TOPIC_DIFFICULTY, "addition");
            topics.Add(topic);
            ArrayList journeys = new ArrayList();
            Journey journey = new Journey(topics);
            journeys.Add(journey);
            Grade grade = new Grade(journeys);

            return new State(grade, journey, topic, difficulty, DisplayTypeEnum.circleDisplay);
        }
    }
}
