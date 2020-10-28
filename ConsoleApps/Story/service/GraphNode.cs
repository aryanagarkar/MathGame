using System.Collections.Generic;
using Service.Util;

namespace service
{
    public class GraphNode
    {
        StoryElement element  { get; set; }
        public MDictionary<string, List<string>> Links { get; set; }


        public GraphNode() {
            Links = new MDictionary<string, List<string>>();
            element = new StoryElement();
         }

        public override bool Equals(object obj)
        {
            GraphNode node = (GraphNode)obj;

            return element.Equals(node.element)
            && Links.Equals(node.Links);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
