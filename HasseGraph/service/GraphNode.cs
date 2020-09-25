using System.Collections.Generic;
using System.Linq;
using Service.Util;
using System;

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
            return this == node;
            //return incomingLinks.getList().SequenceEqual(node.IncomingLinks.getList()) 
            //&& outgoingLinks.getList().SequenceEqual(node.OutgoingLinks.getList());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
