using System.Collections.Generic;
using System;

namespace Service
{
    public class GraphNode
    {
        string id;
        readonly List<string> incomingLinks;
        readonly List<string> outgoingLinks;

        readonly Graph graph;

        GraphNode(Graph graph, string id, List<string> incoming, List<string> outgoing)
        {
            this.graph = graph;
            this.id = id;
            incomingLinks = incoming;
            outgoingLinks = outgoing;
        }

        public Graph Graph
        {
            get { return graph; }
        }

        public string ID
        {
            get { return id; }
        }
        public IList<string> IncomingLinks
        {
            get { return incomingLinks; }
        }

        public IList<string> OutgoingLinks
        {
            get { return outgoingLinks; }
        }

        public override bool Equals(object obj)
        {
            GraphNode node = (GraphNode)obj;
            HashSet<String> thisIncomingLinkSet = new HashSet<string>(incomingLinks);
            HashSet<String> thisOutgoingLinkSet = new HashSet<string>(outgoingLinks);
            HashSet<String> otherIncomingLinkSet = new HashSet<string>(node.incomingLinks);
            HashSet<String> otherOutgoingLinkSet = new HashSet<string>(node.outgoingLinks);
            return id == node.ID
                && thisIncomingLinkSet.SetEquals(
                    otherIncomingLinkSet)
                && thisOutgoingLinkSet.SetEquals(
                    otherOutgoingLinkSet);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public class Builder
        {
            private Graph graph;
            string id;
            readonly List<string> incomingLinks;
            readonly List<string> outgoingLinks;

            public Builder()
            {
                incomingLinks = new List<string>();
                outgoingLinks = new List<string>();
            }

            public Builder withGraph(Graph graph)
            {
                this.graph = graph;
                return this;
            }
            
            public Builder withID(string id)
            {
                this.id = id;
                return this;
            }

            public Builder withIncomingLink(string node)
            {
                this.incomingLinks.Add(node);
                return this;
            }

            public Builder withOutgoingLink(string node)
            {
                this.outgoingLinks.Add(node);
                return this;
            }

            public GraphNode build()
            {
                return new GraphNode(graph, id, incomingLinks, outgoingLinks);
            }
        }
    }
}
