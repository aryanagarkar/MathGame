using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;

namespace Questions
{
public static class Factory
{
    public static Question createQuestion(State state){
        return new Addition(state.Difficulty);
    }
}
}
