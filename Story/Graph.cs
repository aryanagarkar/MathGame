using System;
using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class Graph
    {
        public Dictionary<string, GraphNode> nodes {get; set;}

        // public Graph(Dictionary<string, GraphNode> nodes)
        // {
        //     this.nodes = nodes;
        // }
        public Graph(){}

        public override bool Equals(object obj){
            if(obj == null){
                return false;
            }
            Graph graph = obj as Graph;
            if(nodes.Count == graph.nodes.Count){
                for(int i = 0; i < nodes.Count; i++){
                    string key = nodes.Keys.ElementAt(i);
                    if(graph.nodes[key] == null) {
                        return false;
                    }
                    if(!nodes[key].Equals(graph.nodes[key])) {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
