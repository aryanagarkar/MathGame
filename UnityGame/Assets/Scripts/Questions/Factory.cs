using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Questions
{
public static class Factory
{
    public static Question createQuestion(State state){
        return new Addition(state.Difficulty);
    }
}
}
