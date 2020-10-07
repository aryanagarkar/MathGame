using System.Collections.Generic;
using System.Linq;
using System;

namespace Service
{
    public class GraphAnalysis
    {
        readonly Graph graph;

        List<GraphNode> sortedNodes;

        bool hesse;

        public GraphAnalysis(Graph graph)
        {
            this.graph = graph;
            this.sortedNodes = topologicalSort();
            this.hesse = isHesse();
        }

        public IList<GraphNode> SortedNodes{
            get{return sortedNodes.AsReadOnly();}
        }

        public bool IsHesse{
            get{return hesse;}
        }

        public List<GraphNode> topologicalSort()
        {
            List<GraphNode> sortedNodes = new List<GraphNode>();
            HashSet<GraphNode> startNodes = getSetOfStartNodes();
            List<GraphLink> links = new List<GraphLink>(graph.Links);

            if (!startNodes.Any())
            {
                throw new Exception("Graph is cyclic");
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
                throw new Exception("Graph is cyclic");
            }
            else
            {
                return sortedNodes;
            }
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
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(root);
            while (q.Any())
            {
                GraphNode v = q.Dequeue();
                foreach(string s in v.OutgoingLinks){
                    GraphNode w = graph.IdNodeMap[s];
                    q.Enqueue(w);
                }
            }
            return true;
        }

        private HashSet<GraphNode> getSetOfStartNodes()
        {
            HashSet<GraphNode> startNodes = new HashSet<GraphNode>();
            foreach (GraphNode node in graph.Nodes)
            {
                if (!node.IncomingLinks.Any())
                {
                    startNodes.Add(node);
                }
            }
            return startNodes;
        }

    }
}
