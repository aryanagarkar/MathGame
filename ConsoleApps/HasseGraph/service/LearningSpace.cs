using System.Collections.Generic;
using System.Linq;

namespace Service.graph
{
    public class LearningSpace
    {
        Graph<Concept> graph;
        KnowlegeState currentState;

        List<KnowlegeState> allPossibleStates;

        public LearningSpace(HashSet<GraphLink<Concept>> links)
        {
            currentState = new KnowlegeState();
            Graph<Concept>.Builder builder = new Graph<Concept>.Builder();
            foreach (GraphLink<Concept> link in links)
            {
                builder = builder.addLink(link.Source, link.Target);
            }
            graph = builder.build();

            allPossibleStates = new List<KnowlegeState>();
            getAllValidStates();
        }

        public List<KnowlegeState> AllPossibleStates
        {
            get { return allPossibleStates; }
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

        private List<Concept> generateFringeNodes()
        {
            List<Concept> fringe = new List<Concept>();

            foreach (GraphNode<Concept> node in graph.Nodes)
            {
                fringe.Add(node.Identity);
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

        private HashSet<GraphNode<Concept>> getSetOfStartNodes()
        {
            HashSet<GraphNode<Concept>> startNodes = new HashSet<GraphNode<Concept>>();
            foreach (Concept node in graph.IdNodeMap.Keys)
            {
                if (!graph.IdNodeMap[node].IncomingLinks.Any())
                {
                    startNodes.Add(graph.IdNodeMap[node]);
                }
            }
            return startNodes;
        }
        
        /*This method removes all state from possible states that are not valid*/
        private void getAllValidStates()
        {
            updateAllPossibleStates(new KnowlegeState(), graph.Nodes);
            allPossibleStates.Add(new KnowlegeState());
            HashSet<GraphNode<Concept>> rootNodes = getSetOfStartNodes();

            for (int i = 0; i < allPossibleStates.Count; i++)
            {
                if (allPossibleStates[i].Concepts.Count != 0)
                {
                    bool containsRootNode = false;
                    foreach (GraphNode<Concept> node in rootNodes)
                    {
                        if (allPossibleStates[i].Concepts.Contains(node.Identity))
                        {
                            containsRootNode = true;
                        }
                    }

                    if (containsRootNode == false)
                    {
                        allPossibleStates.Remove(allPossibleStates[i]);
                    }
                }
            }
        }

        /*This is a recursive method that puts all combinations of the nodes
        in the graph into the possible states*/
        private void updateAllPossibleStates(KnowlegeState currentPermutation, IList<GraphNode<Concept>> nodes)
        {
            if (nodes.Count == 0) { return; }
            foreach (GraphNode<Concept> node in nodes)
            {
                List<GraphNode<Concept>> nodesToCombinate = new List<GraphNode<Concept>>(nodes);
                nodesToCombinate.Remove(node);
                KnowlegeState state = new KnowlegeState();
                foreach (Concept concept in currentPermutation.Concepts)
                {
                    state.Concepts.Add(concept);
                }
                state.Concepts.Add(node.Identity);
                if (!allPossibleStates.Contains(state))
                {
                    allPossibleStates.Add(state);
                }

                updateAllPossibleStates(state, nodesToCombinate);
            }
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