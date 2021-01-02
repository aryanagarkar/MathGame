using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Journey
{
    List<Topic> topics;

    public Journey(List<Topic> topics)
    {
        this.topics = topics;
    }

    public List<Topic> Topics
    {
        get { return topics; }
    }

    public Topic getNextTopic(Topic current){
        int currIndex = topics.IndexOf(current);
        if(currIndex == topics.Count - 1){
            return current;
        }
        int next = currIndex + 1;
        return topics[next];
    }
}
