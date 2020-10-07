using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class History
{
    Stack history;

    public History(){
        history = new Stack();
    }

    public void push(State state){
        history.Push(state);
    }

    public State pop(){
        return (State)history.Pop();
    }

    public State peek(){
        return (State)history.Peek();
    }
}
