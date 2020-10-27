using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace state
{
    [System.Serializable]
    public class History
    {
        Stack history;

        public History()
        {
            history = new Stack();
        }

        public bool Empty{
            get{return history.Count == 0; }
        }

        public void push(State state)
        {
            history.Push(state);
        }

        public State pop()
        {
            return (State)history.Pop();
        }

        public State peek()
        {
            return (State)history.Peek();
        }
    }
}
