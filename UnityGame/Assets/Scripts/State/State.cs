using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;
using Story;

namespace state
{
    [System.Serializable]
    public class State
    {
        Grade grade;
        Journey journey;
        Topic topic;
        int difficulty;
        GraphNode currentNode;

        public State(GraphNode currentNode, Grade grade, Journey journey, Topic topic, int difficulty)
        {
            this.currentNode = currentNode;
            this.grade = grade;
            this.journey = journey;
            this.topic = topic;
            this.difficulty = difficulty;
        }

        public Grade Grade
        {
            get { return grade; }
        }

        public Journey Journey
        {
            get { return journey; }
        }

        public Topic Topic
        {
            get { return topic; }
        }

        public int Difficulty
        {
            get { return difficulty; }
        }

        public GraphNode CurrentNode
        {
            get { return currentNode; }
        }
    }
}
