using System.Collections.Generic;
using System.Linq;
using System;
using Service.graph;

namespace Service
{
    public class LearningSpace
    {
        readonly Graph hesseGraph;
        readonly KnowledgeState currentState;
        readonly HashSet<KnowledgeState> Lspace;

        public LearningSpace(Graph hesseGraph, KnowledgeState currentState)
        {
            this.hesseGraph = hesseGraph;
            this.currentState = currentState;
            this.Lspace = generateLearningSpace();
        }

        public KnowledgeState CurrentState{
            get{return currentState;}
        }

        public HashSet<KnowledgeState> learningSpace{
            get{return Lspace;}
        }

        private HashSet<KnowledgeState> generateLearningSpace(){
        }
    }
}
