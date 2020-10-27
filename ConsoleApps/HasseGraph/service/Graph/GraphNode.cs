using System.Collections.Generic;
using System;

namespace Service.graph
{
    public class GraphNode<T>
    {
        T id;
        readonly List<T> incomingLinks;
        readonly List<T> outgoingLinks;

        readonly Graph<T> graph;

        GraphNode(Graph<T> graph, T id, List<T> incoming, List<T> outgoing)
        {
            this.graph = graph;
            this.id = id;
            this.incomingLinks = incoming;
            this.outgoingLinks = outgoing;
        }

        public Graph<T> Graph
        {
            get { return graph; }
        }

        public IList<T> IncomingLinks
        {
            get { return incomingLinks; }
        }

        public IList<T> OutgoingLinks
        {
            get { return outgoingLinks; }
        }

        public T ID
        {
            get { return id; }
        }

        public override bool Equals(object obj)
        {
            GraphNode<T> node = (GraphNode<T>)obj;
            HashSet<T> thisIncomingLinkSet = new HashSet<T>(incomingLinks);
            HashSet<T> thisOutgoingLinkSet = new HashSet<T>(outgoingLinks);
            HashSet<T> otherIncomingLinkSet = new HashSet<T>(node.incomingLinks);
            HashSet<T> otherOutgoingLinkSet = new HashSet<T>(node.outgoingLinks);
            return id.Equals(node.ID)
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
            private Graph<T> graph;
            T id;
            readonly List<T> incomingLinks;
            readonly List<T> outgoingLinks;

            public Builder()
            {
                incomingLinks = new List<T>();
                outgoingLinks = new List<T>();
            }

            public Builder withGraph(Graph<T> graph)
            {
                this.graph = graph;
                return this;
            }

            public Builder withIncomingLink(T node)
            {
                this.incomingLinks.Add(node);
                return this;
            }

            public Builder withOutgoingLink(T node)
            {
                this.outgoingLinks.Add(node);
                return this;
            }


            public Builder withID(T id)
            {
                this.id = id;
                return this;
            }


            public GraphNode<T> build()
            {
                return new GraphNode<T>(graph, id, incomingLinks, outgoingLinks);
            }
        }
    }
}
