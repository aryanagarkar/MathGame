using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;

namespace state
{
    [System.Serializable]
    public class State
    {
        Topic topic;
        int difficulty;

        public State(Topic topic, int difficulty)
        {
            this.topic = topic;
            this.difficulty = difficulty;
        }

        public Topic Topic
        {
            get { return topic; }
        }

        public int Difficulty
        {
            get { return difficulty; }
        }

        public bool IsEqual(State other)
        {
            return (topic == other.topic && difficulty == other.Difficulty);
        }
    }
}
