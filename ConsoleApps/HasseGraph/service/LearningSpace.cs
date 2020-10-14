using System.Collections.Generic;
using System;
using Service.graph;

namespace Service
{
    public class LearningSpace
    {
        readonly Graph hesseGraph;
        readonly KnowledgeState currentState;

        readonly List<KnowledgeState> space;

        public LearningSpace(Graph hesseGraph, KnowledgeState currentState)
        {
            this.hesseGraph = hesseGraph;
            this.currentState = currentState;
            // this.space = setupAndGenerateLearningSpace();
        }

        public KnowledgeState CurrentState
        {
            get { return currentState; }
        }

        public Graph HesseGraph
        {
            get { return hesseGraph; }
        }

        public List<KnowledgeState> learningSpace
        {
            get { return space; }
        }

        public List<KnowledgeState> setupAndGenerateLearningSpace()
        {
            Dictionary<string, int> Np = new Dictionary<string, int>();
            foreach (string n in hesseGraph.IdNodeMap.Keys)
            {
                Np.Add(n, hesseGraph.IdNodeMap[n].IncomingLinks.Count);
            }

            List<string> C_S = new List<string>();
            foreach (string key in Np.Keys)
            {
                if (Np[key] == 0)
                {
                    C_S.Add(key);
                }
            }

            KnowledgeState state = new KnowledgeState.Builder()
                            .withGraph(hesseGraph)
                            .build();
            
            KnowledgeState.Builder fullStateBuilder = new KnowledgeState.Builder()
                            .withGraph(hesseGraph);

            foreach(string n in hesseGraph.IdNodeMap.Keys){
                fullStateBuilder = fullStateBuilder.withConcept(n);
            }

            List<KnowledgeState> L = new List<KnowledgeState>();
            L.Add(state);
            L.Add(fullStateBuilder.build());

            return generateLearningSpace(L, state, Np, C_S);
        }

        private List<KnowledgeState> generateLearningSpace(List<KnowledgeState> L, KnowledgeState state,
        Dictionary<string, int> Np, List<string> C_S)
        {
            if (L.Count == Math.Pow(2, hesseGraph.IdNodeMap.Keys.Count)) { return L; }
            List<GraphNode> T = new GraphAnalysis(hesseGraph).SortedNodes;

            for (int i = 0; i < C_S.Count; i++)
            {
                if (!state.Concepts.Contains(C_S[i]))
                {       
                    KnowledgeState newState = new KnowledgeState();
                    KnowledgeState.Builder newStateBuilder = new KnowledgeState.Builder().withGraph(hesseGraph);
                    foreach (string c in state.Concepts)
                    {
                        newStateBuilder = newStateBuilder.withConcept(c);
                    }
                    newStateBuilder = newStateBuilder.withConcept(C_S[i]);

                    newState = newStateBuilder.build();
                    if (!L.Contains(newState))
                    {
                        L.Add(newState);
                    }
                }
                foreach (string s in hesseGraph.IdNodeMap[C_S[i]].OutgoingLinks)
                {
                    Np[s]--;
                    if (Np[s] == 0 && !C_S.Contains(s))
                    {
                        C_S.Add(s);
                    }
                }
                foreach (string n in hesseGraph.IdNodeMap[C_S[i]].IncomingLinks)
                {
                    if (T.IndexOf(hesseGraph.IdNodeMap[n]) < T.IndexOf(hesseGraph.IdNodeMap[C_S[i]]))
                    {
                        C_S.Remove(n);
                    }
                }
            }

            return generateLearningSpace(L, L[L.Count - 1], Np, C_S);

            // if (state.Concepts.Count == hesseGraph.Nodes.Count) { return L; }

            // foreach (string x in C_S)
            // {
            //     state.Concepts.Add(x);
            //     L.Add(state);
            //     foreach (string y in hesseGraph.IdNodeMap[x].OutgoingLinks)
            //     {
            //         Np[y]--;
            //         if (Np[y] == 0)
            //         {
            //             C_S.Add(y);
            //         }

            //         for (int i = 0; i < T.IndexOf(hesseGraph.IdNodeMap[x]); i++)
            //         {
            //             if (Np[T[i].ID] == 0)
            //             {
            //                 C_S.Remove(T[i].ID);
            //             }
            //         }

            //         // generateLearningSpace(state, Np, C_S);

            //         foreach (string n in hesseGraph.IdNodeMap[x].OutgoingLinks)
            //         {
            //             Np[n]++;
            //         }
            //     }
            // }
            // return L;
        }

        public override bool Equals(object obj)
        {
            LearningSpace other = (LearningSpace)obj;
            return hesseGraph.Equals(other.HesseGraph) && currentState.Equals(other.currentState);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
