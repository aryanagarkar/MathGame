using System.Collections.Generic;
using System.Linq;
using System;

namespace Service.graph
{
    public class GraphAnalysis<T>
    {
        readonly Graph<T> graph;

        /*A null value means that there is no topological sort for the given graph,
        i.e. The graph is cyclic*/
        readonly List<GraphNode<T>> sortedNodes;

        public GraphAnalysis(Graph<T> graph)
        {
            this.graph = graph;
            this.sortedNodes = topologicalSort();
        }

        public List<GraphNode<T>> SortedNodes
        {
            get { return sortedNodes; }
        }

        /*A ordering of graph nodes where for each edge x to y in the graph,
         x comes before y in the ordering*/
        public List<GraphNode<T>> topologicalSort()
        {
            List<GraphNode<T>> sortedNodes = new List<GraphNode<T>>();
            HashSet<GraphNode<T>> startNodes = getSetOfStartNodes();
            List<GraphLink<T>> links = new List<GraphLink<T>>(graph.Links);

            if (!startNodes.Any())
            {
                return null;
            }

            while (startNodes.Any())
            {
                GraphNode<T> node = startNodes.ElementAt(0);
                startNodes.Remove(node);
                if(!sortedNodes.Contains(node)){
                    sortedNodes.Add(node);
                }

                foreach (T c in node.OutgoingLinks)
                {
                    List<T> inLinks = new List<T>(graph.IdNodeMap[c].IncomingLinks);
                    inLinks.Remove(node.Identity);
                    for (int i = 0; i < links.Count; i++)
                    {
                        if (links[i].Source.Equals(node.Identity) && links[i].Target.Equals(c))
                        {
                            links.Remove(links[i]);
                        }
                    }
                    if (!startNodes.Contains(graph.IdNodeMap[c]))
                    {
                        startNodes.Add(graph.IdNodeMap[c]);
                    }
                }
            }
            return sortedNodes;
        }

        public bool isCyclic()
        {
            return sortedNodes == null;
        }

        /*A hasse graph is a directed, acyclic graph where if there are edges x to y and y to z,
         then x to z is not an edge*/
        public Boolean isHesse()
        {
            HashSet<GraphNode<T>> roots = getSetOfStartNodes();
            foreach (GraphNode<T> rootNode in roots)
            {
                if (!isReduced(rootNode))
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean isReduced(GraphNode<T> root)
        {
            List<GraphNode<T>> nodesVisited = new List<GraphNode<T>>();
            Queue<GraphNode<T>> q = new Queue<GraphNode<T>>();
            q.Enqueue(root);
            while (q.Any())
            {
                GraphNode<T> v = q.Dequeue();
                foreach (T c in v.OutgoingLinks)
                {
                    GraphNode<T> w = graph.IdNodeMap[c];
                    if (nodesVisited.Contains(w)) { return false; }
                    nodesVisited.Add(w);
                    q.Enqueue(w);
                }
            }
            return true;
        }

        private HashSet<GraphNode<T>> getSetOfStartNodes()
        {
            HashSet<GraphNode<T>> startNodes = new HashSet<GraphNode<T>>();
            foreach (T node in graph.IdNodeMap.Keys)
            {
                if (!graph.IdNodeMap[node].IncomingLinks.Any())
                {
                    startNodes.Add(graph.IdNodeMap[node]);
                }
            }
            return startNodes;
        }

    }
}
