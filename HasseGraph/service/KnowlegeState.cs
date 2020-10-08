using System.Collections.Generic;
using System.Linq;
using System;
using Service.graph;

namespace Service
{
    public class KnowledgeState
    {
        readonly Graph hesseGraph;
        readonly List<string> concepts;
        readonly List<string> fringe;

        public KnowledgeState(Graph hasseGraph, List<string> concepts)
        {
            this.hesseGraph = hasseGraph;
            this.concepts = concepts;
            this.fringe = generateFringe();
        }

        public List<string> Concepts
        {
            get { return concepts; }
        }

        public List<string> Fringe
        {
            get { return fringe; }
        }

        private List<string> generateFringe()
        {
            List<String> fringeSet = new List<string>(hesseGraph.Nodes);
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
            List<string> concepts;

            public Builder()
            {
                hesseGraph = new Graph();
                concepts = new List<string>();
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
