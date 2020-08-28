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

    public State(Grade grade, Journey journey, Topic topic, int difficulty){
        this.grade = grade;
        this.journey = journey;
        this.topic = topic;
        this.difficulty = difficulty;
    }

    public Grade Grade{
        get{return grade; }
        set{value = grade; }
    }

    public Journey Journey{
        get{return journey; }
        set{ value = journey; }
    }

    public Topic Topic{
        get{return topic; }
        set{value = topic; }
    }

    public int Difficulty{
        get{return difficulty; }
        set{value = difficulty; }
    }

    public bool isEqual(State other)
    {
        if(grade == other.Grade && journey == other.Journey
         && topic == other.topic && difficulty == other.Difficulty){
            return true;
        }
        return false;
    }
}
