using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class GraphNode
    {
        readonly MList<GraphNode> incomingLinks;
        readonly MList<GraphNode> outgoingLinks;

        internal GraphNode()
        {
            incomingLinks = new MList<GraphNode>();
            outgoingLinks = new MList<GraphNode>();
        }

        public MList<GraphNode> IncomingLinks
        {
            get { return incomingLinks; }
        }

        public MList<GraphNode> OutgoingLinks
        {
            get { return outgoingLinks; }
        }

        public override bool Equals(object obj)
        {
            GraphNode node = (GraphNode)obj;
            return incomingLinks.SequenceEqual(node.IncomingLinks) && outgoingLinks.SequenceEqual(node.OutgoingLinks);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
