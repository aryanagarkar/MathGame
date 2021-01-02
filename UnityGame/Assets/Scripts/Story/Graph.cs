using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Story
{
    [DataContract]
    [System.Serializable]
    public class Graph
    {
        [DataMember]
        public List<GraphNode> Nodes { get; set; }

        public Graph() {
            Nodes = new List<GraphNode>();
         }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Graph graph = obj as Graph;
            return Nodes.SequenceEqual(graph.Nodes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
