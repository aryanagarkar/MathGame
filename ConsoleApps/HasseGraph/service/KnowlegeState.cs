using System.Collections.Generic;
using System.Collections.Immutable;
using System;
using Service.graph;

namespace Service
{
    public class KnowledgeState
    {
        readonly Graph hesseGraph;
        readonly HashSet<string> concepts;
        readonly HashSet<string> fringe;

        public KnowledgeState(Graph hasseGraph, HashSet<string> concepts)
        {
            this.hesseGraph = hasseGraph;
            this.concepts = concepts;
            this.fringe = generateFringe();
        }


        public KnowledgeState(){
            this.hesseGraph = new Graph();
            this.concepts = new HashSet<string>();
            this.fringe = new HashSet<string>();
        }

        public HashSet<string> Concepts
        {
            get { return concepts; }
        }

        public HashSet<string> Fringe
        {
            get { return fringe; }
        }

        public Graph HesseGraph{
            get{return hesseGraph;}
        }

        private HashSet<string> generateFringe()
        {
            HashSet<String> fringeSet = new HashSet<String>(hesseGraph.IdNodeMap.Keys);
            foreach (GraphLink link in hesseGraph.Links)
            {
                if (!concepts.Contains(link.Source))
                {
                    fringeSet.Remove(link.Target);
                }
                if (concepts.Contains(link.Target))
                {
                    fringeSet.Remove(link.Source);
                }
            }
            return fringeSet;
            
        }

        public override bool Equals(object obj){
            KnowledgeState other = (KnowledgeState)obj;
            return concepts.SetEquals(other.concepts) && fringe.SetEquals(other.fringe) 
            && hesseGraph.Equals(other.HesseGraph);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public class Builder
        {
            Graph hesseGraph;
            HashSet<string> concepts;

            public Builder()
            {
                hesseGraph = new Graph();
                concepts = new HashSet<string>();
            }

            public KnowledgeState.Builder withGraph(Graph graph){
                this.hesseGraph = graph;
                return this;
            }

            public KnowledgeState.Builder withConcept(String concept){
                this.concepts.Add(concept);
                return this;
            }

            public KnowledgeState build(){
                return new KnowledgeState(hesseGraph, concepts);
            }
        }
    }
}
