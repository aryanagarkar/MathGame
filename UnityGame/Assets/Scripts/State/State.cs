using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;

[System.Serializable]
public class State
{
    Topic topic;
    int difficulty;
    DisplayTypeEnum displayType;

    public State(Topic topic, int difficulty, DisplayTypeEnum displayType)
    {
        this.topic = topic;
        this.difficulty = difficulty;
        this.displayType = displayType;
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
        return (topic == other.topic && difficulty == other.Difficulty && displayType == other.displayType);
    }
}
