using Service.Util;

namespace service
{
    public class Graph
    {
        public MDictionary<string, GraphNode> Nodes { get; set; }

        public Graph() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Graph graph = obj as Graph;
            return Nodes.Equals(graph.Nodes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
