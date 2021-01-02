using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grade
{
    List<Journey> journeys;

    public Grade(List<Journey> journeys)
    {
        journeys = journeys;
    }

    public List<Journey> Journeys
    {
        get { return journeys; }
    }
}
