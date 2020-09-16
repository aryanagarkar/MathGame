using System.Collections.Generic;
using System.Linq;
using Service.Util;

namespace service
{
    public class Graph
    {
        public MDictionary<string, GraphNode> nodes { get; set; }

        public Graph() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Graph graph = obj as Graph;
            return nodes.Equals(graph.nodes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
