using System.Collections.Generic;
using Service.graph;

namespace Service
{
    public class LearningSpace
    {
        readonly Graph hesseGraph;
        readonly KnowledgeState currentState;

        public LearningSpace(Graph hesseGraph, KnowledgeState currentState)
        {
            this.hesseGraph = hesseGraph;
            this.currentState = currentState;
        }

        public KnowledgeState CurrentState
        {
            get { return currentState; }
        }

        private HashSet<KnowledgeState> setupAndGenerateLearningSpace()
        {
            Dictionary<string, int> Np = new Dictionary<string, int>();
            foreach (string n in hesseGraph.Nodes)
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

            return generateLearningSpace(state, Np, C_S);
        }

        private HashSet<KnowledgeState> generateLearningSpace(KnowledgeState state, Dictionary<string, int> Np,
        List<string> C_S)
        {
            HashSet<KnowledgeState> L = new HashSet<KnowledgeState>();
            GraphAnalysis analysis = new GraphAnalysis(hesseGraph);
            List<GraphNode> T = analysis.SortedNodes;

            if (state.Concepts.Count == hesseGraph.Nodes.Count) { return L; }

            foreach (string x in C_S)
            {
                state.Concepts.Add(x);
                L.Add(state);
                foreach (string y in hesseGraph.IdNodeMap[x].OutgoingLinks)
                {
                    Np[y]--;
                    if (Np[y] == 0)
                    {
                        C_S.Add(y);
                    }

                    for (int i = 0; i < T.IndexOf(hesseGraph.IdNodeMap[x]); i++)
                    {
                        if (Np[T[i].ID] == 0)
                        {
                            C_S.Remove(T[i].ID);
                        }
                    }

                    generateLearningSpace(state, Np, C_S);

                    foreach (string n in hesseGraph.IdNodeMap[x].OutgoingLinks)
                    {
                        Np[n]++;
                    }
                }
            }
            return L;
            // 	           For each x in C_S {
            // 		       S = S ∪ {x}
            //             L += S		
            // 	           Decrement Np(y) for each	y	s.t.	x -> y
            //             Compute C_S ∪ {x}  from C_S:
            // 			   Remove:	any y, s.t. y prior to x in the topological order
            // 			   Add:		any y, s.t. x → y iff Np(y) = 0   [all other prererequisites of y already in S]

            // 		       C = C(S ∪ {x})

            // 		       Function(S, C, Np)

            // 	           Increment Np(y) for each	y	s.t.	x -> y
        }
    }
}
