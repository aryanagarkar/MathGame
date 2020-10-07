using System.Collections.Generic;
using System.Linq;
using Service.Util;
using System;

namespace service
{
    public class GraphNode
    {
        public string Character { get; set; }
        public List<string> Conversations { get; set; }
        public MDictionary<string, List<string>> Links { get; set; }


        public GraphNode() { }

        public override bool Equals(object obj)
        {
            GraphNode node = (GraphNode)obj;

            return Character.Equals(node.Character) 
            && Conversations.SequenceEqual(node.Conversations) 
            && Links.Equals(node.Links);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
