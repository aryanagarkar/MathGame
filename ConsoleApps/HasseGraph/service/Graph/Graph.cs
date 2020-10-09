using Service.Util;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Service.graph
{
    public class Graph
    {
        readonly MDictionary<string, GraphNode> idNodeMap;
        readonly List<GraphLink> links = new List<GraphLink>();

        Graph(MDictionary<string, GraphNode> idNodeMap, List<GraphLink> links)
        {
            this.idNodeMap = idNodeMap;
            this.links = links;
        }

        public Graph(){}

        public IDictionary<string, GraphNode> IdNodeMap
        {
            get { return idNodeMap.getReadOnlyDictionary(); }
        }

        public IList<String> Nodes
        {
            get { return idNodeMap.Keys.ToList().AsReadOnly(); }
        }

        public IList<GraphLink> Links
        {
            get { return links.AsReadOnly(); }
        }

        public override bool Equals(object obj)
        {
            Graph graph = (Graph)obj;
            HashSet<string> thisNodes = new HashSet<string>(Nodes);
            HashSet<string> otherNodes = new HashSet<string>(graph.Nodes);

            return thisNodes.SetEquals(otherNodes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public class Builder
        {
            MDictionary<string, GraphNode.Builder> idNodeMap = new MDictionary<string, GraphNode.Builder>();
            List<GraphLink> links = new List<GraphLink>();

            public Builder() { }

            public Builder addLink(string sourceId, string targetId)
            {
                foreach (GraphLink link in links)
                {
                    if (link.Source.Equals(sourceId) && link.Target.Equals(targetId))
                    {
                        throw new InvalidOperationException("Cannot add duplicate node");
                    }
                }
                
                GraphNode.Builder sourceNode = addOrGetNode(sourceId);
                GraphNode.Builder targetNode = addOrGetNode(targetId);
                links.Add(new GraphLink.Builder().withSource(sourceId).withTarget(targetId).build());
                sourceNode.withOutgoingLink(targetId);
                targetNode.withIncomingLink(sourceId);

                return this;
            }

            public Graph build()
            {
                return new Graph(
                    new MDictionary<string, GraphNode>(idNodeMap.ToDictionary(
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
