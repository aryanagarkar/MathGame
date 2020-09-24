using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class GraphNode
    {
        readonly List<GraphNode> incomingLinks;
        readonly List<GraphNode> outgoingLinks;


        public GraphNode()
        {
            incomingLinks = new MList<GraphNode>();
            outgoingLinks = new MList<GraphNode>();
        }

        public List<GraphNode> IncomingLinks
        {
            get { return incomingLinks; }
        }

        public List<GraphNode> OutgoingLinks
        {
            get { return outgoingLinks; }
        }

        public override bool Equals(object obj){
            GraphNode node = (GraphNode)obj; 
            return incomingLinks.SequenceEqual(node.IncomingLinks) && outgoingLinks.SequenceEqual(node.OutgoingLinks);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }   
}
