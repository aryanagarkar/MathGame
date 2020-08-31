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
            StateMachine stateMachine = createStateMachineFor(2);

            // Test
            State newState = stateMachine.processEvent(EventTypes.rightAnswerEvent);

            // Assertions
            State state = stateMachine.CurrentHistory.peek();
            State expected = new State(state.Grade, state.Journey, state.Topic, state.Difficulty + 1, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }


        [Test]
        public void testNoChangeInDifficultyAtMaxDifficulty_rightAnswer()
        {
            // Setup
            StateMachine stateMachine = createStateMachineFor(5);

            // Test
            State newState = stateMachine.processEvent(EventTypes.rightAnswerEvent);

            // Assertions
                State state = stateMachine.CurrentHistory.peek();
            State expected = new State(state.Grade, state.Journey, state.Topic, state.Difficulty, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }

        [Test]
        public void testDifficultyDecreasesForDifficultyGreaterThanOne_wrongAnswer()
        {
            // Setup
            StateMachine stateMachine = createStateMachineFor(2);

            // Test
            State newState = stateMachine.processEvent(EventTypes.wrongAnswerEvent);

            // Assertions
                State state = stateMachine.CurrentHistory.peek();
            State expected = new State(state.Grade, state.Journey, state.Topic, state.Difficulty - 1, state.DisplayType);
            Assert.IsTrue(newState.IsEqual(expected));
        }

        [Test]
        public void testNoChangeInDifficultyForAtMinDifficulty_wrongAnswer()
        {
            // Setup
            StateMachine stateMachine = createStateMachineFor(1);

            // Test
            State newState = stateMachine.processEvent(EventTypes.wrongAnswerEvent);

            // Assertions
                State state = stateMachine.CurrentHistory.peek();
            State expected = new State(state.Grade, state.Journey, state.Topic, state.Difficulty, state.DisplayType);
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

        private StateMachine createStateMachineFor(int difficulty){
            State state = createStateFor(difficulty);

            History history = new History();
            history.push(state);

            return new StateMachine(history);
        }
    }
}
