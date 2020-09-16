using System.Collections.Generic;
using System.Linq;
using Service.Util;
using System;

namespace service
{
    public class GraphNode
    {
        public string character { get; set; }
        public List<string> conversations { get; set; }
        public MDictionary<string, List<string>> links { get; set; }


        public GraphNode() { }

        public override bool Equals(object obj)
        {
            GraphNode node = (GraphNode)obj;

            return character.Equals(node.character) 
            && conversations.SequenceEqual(node.conversations) 
            && links.Equals(node.links);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
