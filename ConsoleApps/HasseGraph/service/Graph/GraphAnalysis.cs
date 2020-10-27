using System.Collections.Generic;
using System.Linq;
using System;

namespace Service.graph
{
    public class GraphAnalysis<T>
    {
        readonly Graph<T> graph;

        readonly List<GraphNode<T>> sortedNodes;

        public GraphAnalysis(Graph<T> graph)
        {
            this.graph = graph;
            this.sortedNodes = topologicalSort();
        }

        public List<GraphNode<T>> SortedNodes{
            get{return sortedNodes;}
        }

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
                GraphNode<T> node = startNodes.ElementAt(startNodes.Count - 1);
                startNodes.Remove(node);
                sortedNodes.Add(node);

                foreach (T c in node.OutgoingLinks)
                {
                    List<T> inLinks = new List<T>(graph.IdNodeMap[c].IncomingLinks);
                    inLinks.Remove(node.ID);
                    for (int i = 0; i < links.Count; i++)
                    {
                        if (links[i].Source.Equals(node.ID) && links[i].Target.Equals(c))
                        {
                            links.Remove(links[i]);
                        }
                    }
                    if (!inLinks.Any())
                    {
                        startNodes.Add(graph.IdNodeMap[c]);
                    }
                }
            }
            if (links.Any())
            {
                return null;
            }
            else
            {
                return sortedNodes;
            }
        }

        public bool isCyclic(){
            if(sortedNodes == null){
                return true;
            }
            return false;
        }

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
                foreach(T c in v.OutgoingLinks){
                    GraphNode<T> w = graph.IdNodeMap[c];
                    if(nodesVisited.Contains(w)){return false;}
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
