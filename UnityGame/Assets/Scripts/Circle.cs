using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    bool right;

    public bool Right
    {
        set { right = value; }
    }

    void OnMouseDown()
    {
        if (right == true)
        {
            Camera.main.GetComponent<GameController>().rightAnswerEvent();
        }
        else
        {
            Camera.main.GetComponent<GameController>().wrongAnswerEvent();
        }
    }
}