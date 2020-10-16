using System.Collections.Generic;
using System.Linq;
using System;

namespace Service.graph
{
    public class GraphAnalysis
    {
        readonly Graph graph;

        readonly List<GraphNode> sortedNodes;

        public GraphAnalysis(Graph graph)
        {
            this.graph = graph;
            this.sortedNodes = topologicalSort();
        }

        public List<GraphNode> SortedNodes{
            get{return sortedNodes;}
        }

        public List<GraphNode> topologicalSort()
        {
            List<GraphNode> sortedNodes = new List<GraphNode>();
            HashSet<GraphNode> startNodes = getSetOfStartNodes();
            List<GraphLink> links = new List<GraphLink>(graph.Links);

            if (!startNodes.Any())
            {
                return null;
            }

            while (startNodes.Any())
            {
                GraphNode node = startNodes.ElementAt(startNodes.Count - 1);
                startNodes.Remove(node);
                sortedNodes.Add(node);

                foreach (string s in node.OutgoingLinks)
                {
                    List<string> inLinks = new List<string>(graph.IdNodeMap[s].IncomingLinks);
                    inLinks.Remove(node.ID);
                    for (int i = 0; i < links.Count; i++)
                    {
                        if (links[i].Source.Equals(node.ID) && links[i].Target.Equals(s))
                        {
                            links.Remove(links[i]);
                        }
                    }
                    if (!inLinks.Any())
                    {
                        startNodes.Add(graph.IdNodeMap[s]);
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
            HashSet<GraphNode> roots = getSetOfStartNodes();
            foreach (GraphNode rootNode in roots)
            {
                if (!isReduced(rootNode))
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean isReduced(GraphNode root)
        {
            List<GraphNode> nodesVisited = new List<GraphNode>();
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(root);
            while (q.Any())
            {
                GraphNode v = q.Dequeue();
                foreach(string s in v.OutgoingLinks){
                    GraphNode w = graph.IdNodeMap[s];
                    if(nodesVisited.Contains(w)){return false;}
                    nodesVisited.Add(w);
                    q.Enqueue(w);
                }
            }
            return true;
        }

        private HashSet<GraphNode> getSetOfStartNodes()
        {
            HashSet<GraphNode> startNodes = new HashSet<GraphNode>();
            foreach (string node in graph.IdNodeMap.Keys)
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
