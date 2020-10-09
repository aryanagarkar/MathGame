using System.Collections.Generic;
using System.Linq;
using System;
using Service.graph;

namespace Service
{
    public class KnowledgeState
    {
        readonly Graph hesseGraph;
        HashSet<string> concepts;
        HashSet<string> fringe;

        public KnowledgeState(Graph hasseGraph, HashSet<string> concepts)
        {
            this.hesseGraph = hasseGraph;
            this.concepts = concepts;
            this.fringe = generateFringe();
        }

        public HashSet<string> Concepts
        {
            get { return concepts; }
        }

        public HashSet<string> Fringe
        {
            get { return fringe; }
        }

        private HashSet<string> generateFringe()
        {
            HashSet<String> fringeSet = new HashSet<string>(hesseGraph.Nodes);
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
