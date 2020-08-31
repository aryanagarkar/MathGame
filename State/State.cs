using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;

[System.Serializable]
public class State
{
    Grade grade;
    Journey journey;
    Topic topic;
    int difficulty;
    DisplayTypeEnum displayType;

    public State(Grade grade, Journey journey, Topic topic, int difficulty, DisplayTypeEnum displayType)
    {
        this.grade = grade;
        this.journey = journey;
        this.topic = topic;
        this.difficulty = difficulty;
        this.displayType = displayType;
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

    public DisplayTypeEnum DisplayType
    {
        get { return displayType; }
    }

    public bool IsEqual(State other)
    {
        return (grade == other.Grade && journey == other.Journey
             && topic == other.topic && difficulty == other.Difficulty && displayType == other.displayType);
    }
}
