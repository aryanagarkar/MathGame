using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;

namespace Questions
{
public static class Factory
{
    public static Question createQuestion(State state){
        if(state.Topic.QuestionType.ToString().Equals("adiition")){
             return new Addition(state.Difficulty);
        }
        if(state.Topic.QuestionType.ToString().Equals("subtraction")){
             return new Subtraction(state.Difficulty);
        }
         if(state.Topic.QuestionType.ToString().Equals("multiplication")){
             return new Multiplication(state.Difficulty);
        }
         if(state.Topic.QuestionType.ToString().Equals("division")){
             return new Division(state.Difficulty);
        }
        return new Addition(state.Difficulty);
    }
}
}
