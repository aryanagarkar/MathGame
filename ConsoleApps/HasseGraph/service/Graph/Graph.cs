using System.Collections.Generic;
using System.Linq;
using System;

namespace Service.graph
{
    public class Graph
    {
        readonly Dictionary<string, GraphNode> idNodeMap;
        readonly List<GraphLink> links = new List<GraphLink>();

        Graph(Dictionary<string, GraphNode> idNodeMap, List<GraphLink> links)
        {
            this.idNodeMap = idNodeMap;
            this.links = links;
        }

        public Graph() { }

        public IDictionary<string, GraphNode> IdNodeMap
        {
            get { return idNodeMap; }
        }

        public IList<GraphLink> Links
        {
            get { return links.AsReadOnly(); }
        }

        public override bool Equals(object obj)
        {
            Graph graph = (Graph)obj;
            HashSet<string> thisNodes = new HashSet<string>(idNodeMap.Keys.ToHashSet());
            HashSet<string> otherNodes = new HashSet<string>(graph.idNodeMap.Keys);

            return thisNodes.SetEquals(otherNodes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public class Builder
        {
            Dictionary<string, GraphNode.Builder> idNodeMap;
            List<GraphLink> links;

            public Builder()
            {
                this.idNodeMap = new Dictionary<string, GraphNode.Builder>();
                this.links = new List<GraphLink>();
            }

            public Builder addLink(string sourceId, string targetId)
            {
                bool containsLink = false;
                foreach (GraphLink link in links)
                {
                    if (link.Source.Equals(sourceId) && link.Target.Equals(targetId))
                    {
                        containsLink = true;
                    }
                }

                if (containsLink == false)
                {
                    GraphNode.Builder sourceNode = addOrGetNode(sourceId);
                    GraphNode.Builder targetNode = addOrGetNode(targetId);
                    links.Add(new GraphLink.Builder().withSource(sourceId).withTarget(targetId).build());
                    sourceNode = sourceNode.withOutgoingLink(targetId);
                    targetNode = targetNode.withIncomingLink(sourceId);

                }
                return this;
            }

            public Graph build()
            {
                return new Graph(
                    new Dictionary<string, GraphNode>(idNodeMap.ToDictionary(
                        kvp1 => kvp1.Key, kvp2 => kvp2.Value.build())),
                    links);
            }

            private GraphNode.Builder addOrGetNode(string id)
            {
                if (!idNodeMap.ContainsKey(id))
                {
                    GraphNode.Builder node = new GraphNode.Builder().withID(id);
                    idNodeMap.Add(id, node);
                }
                return idNodeMap[id];
            }
        }
    }


}
