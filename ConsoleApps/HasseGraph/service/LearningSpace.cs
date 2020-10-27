using System;
using System.Collections.Generic;

namespace Service.graph
{
    public class LearningSpace
    {
        Graph<Concept> graph;
        KnowlegeState currentState;

        public LearningSpace(HashSet<GraphLink<Concept>> links)
        {
            currentState = new KnowlegeState.Builder().build();
            Graph<Concept>.Builder builder = new Graph<Concept>.Builder();
            foreach (GraphLink<Concept> link in links)
            {
                builder = builder.addLink(link.Source, link.Target);
            }
            graph = builder.build();
        }

        public List<KnowlegeState> setUpAndgeneratePossibleStates()
        {
            List<KnowlegeState> L = new List<KnowlegeState>();

            Dictionary<Concept, int> np = new Dictionary<Concept, int>();
            foreach (GraphNode<Concept> node in graph.Nodes)
            {
                np.Add(node.ID, node.IncomingLinks.Count);
            }

            List<Concept> cs = new List<Concept>();

            foreach (Concept n in np.Keys)
            {
                if (np[n] == 0)
                {
                    cs.Add(n);
                }
            }

            KnowlegeState emptyState = new KnowlegeState.Builder().build();
            L.Add(emptyState);

            return generatePossibleStates(L, emptyState, np, cs);
        }

        public List<Concept> getLearnableConcepts()
        {
            List<Concept> learnableConcepts = generateFringeNodes();

            for (int i = 0; i < learnableConcepts.Count; i++)
            {
                if (currentState.Concepts.Contains(learnableConcepts[i]))
                {
                    learnableConcepts.Remove(learnableConcepts[i]);
                }
            }

            return learnableConcepts;
        }

        public List<Concept> getRecentlyLearnedConcepts()
        {
            List<Concept> recentlyLearnedConcepts = generateFringeNodes();

            for (int i = 0; i < recentlyLearnedConcepts.Count; i++)
            {
                if (!currentState.Concepts.Contains(recentlyLearnedConcepts[i]))
                {
                    recentlyLearnedConcepts.Remove(recentlyLearnedConcepts[i]);
                }
            }

            return recentlyLearnedConcepts;
        }

        public void addLearnedConcept(Concept c)
        {
            if (!currentState.Concepts.Contains(c))
            {
                currentState.Concepts.Add(c);
            }
        }

        private List<KnowlegeState> generatePossibleStates(List<KnowlegeState> L, KnowlegeState state,
        Dictionary<Concept, int> np, List<Concept> cs)
        {
            GraphAnalysis<Concept> analysis = new GraphAnalysis<Concept>(graph);
            List<GraphNode<Concept>> T = analysis.SortedNodes;

            List<Concept> c = new List<Concept>(cs);
            KnowlegeState newState = new KnowlegeState.Builder().build();

            if (state.Concepts.Count == graph.Nodes.Count) { return L; }
            for (int i = 0; i < cs.Count; i++)
            {
                foreach (Concept concept in state.Concepts)
                {
                    newState.Concepts.Add(concept);
                }
                newState.Concepts.Add(cs[i]);

                if (!L.Contains(newState))
                {
                    L.Add(newState);
                }

                foreach (Concept y in graph.IdNodeMap[cs[i]].OutgoingLinks)
                {
                    if (np[y] > 0)
                    {
                        np[y]--;
                    }
                    if (np[y] == 0 && !cs.Contains(y))
                    {
                        c.Add(y);
                    }
                }
                foreach (GraphNode<Concept> y2 in T)
                {
                    if (T.IndexOf(y2) < T.IndexOf(graph.IdNodeMap[cs[i]]))
                    {
                        c.Remove(y2.ID);
                    }
                }
            }
            return generatePossibleStates(L, newState, np, c);
        }

        private List<Concept> generateFringeNodes()
        {
            List<Concept> fringe = new List<Concept>();

            foreach (GraphNode<Concept> node in graph.Nodes)
            {
                fringe.Add(node.ID);
            }

            foreach (GraphLink<Concept> link in graph.Links)
            {
                if (!currentState.Concepts.Contains(link.Source))
                {
                    fringe.Remove(link.Target);
                }
                if (currentState.Concepts.Contains(link.Target))
                {
                    fringe.Remove(link.Source);
                }
            }
            return fringe;
        }

        public class Builder
        {
            HashSet<GraphLink<Concept>> links;

            public Builder()
            {
                links = new HashSet<GraphLink<Concept>>();
            }

            public LearningSpace.Builder withLink(Concept c1, Concept c2)
            {
                GraphLink<Concept> link = new GraphLink<Concept>.Builder()
                                              .withSource(c1)
                                              .withTarget(c2)
                                              .build();

                links.Add(link);
                return this;
            }

            public LearningSpace build()
            {
                return new LearningSpace(links);
            }
        }
    }
}
