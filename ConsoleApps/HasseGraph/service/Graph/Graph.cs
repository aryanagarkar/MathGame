using System.Collections.Generic;
using System.Linq;
using System;

namespace Service.graph
{
    public class Graph<T>
    {
        readonly Dictionary<T, GraphNode<T>> idNodeMap;
        readonly List<GraphLink<T>> links = new List<GraphLink<T>>();

        Graph(Dictionary<T, GraphNode<T>> idNodeMap, List<GraphLink<T>> links)
        {
            this.idNodeMap = idNodeMap;
            this.links = links;
        }

        public Graph() { }

        public IDictionary<T, GraphNode<T>> IdNodeMap
        {
            get { return idNodeMap; }
        }

        public IList<GraphNode<T>> Nodes
        {
            get { return idNodeMap.Values.Distinct().ToList(); }
        }


        public IList<GraphLink<T>> Links
        {
            get { return links.AsReadOnly(); }
        }

        public override bool Equals(object obj)
        {
            Graph<T> graph = (Graph<T>)obj;
            HashSet<T> thisNodes = new HashSet<T>(idNodeMap.Keys.ToHashSet());
            HashSet<T> otherNodes = new HashSet<T>(graph.idNodeMap.Keys);

            return thisNodes.SetEquals(otherNodes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public class Builder
        {
            Dictionary<T, GraphNode<T>.Builder> idNodeMap;
            List<GraphLink<T>> links;

            public Builder()
            {
                this.idNodeMap = new Dictionary<T, GraphNode<T>.Builder>();
                this.links = new List<GraphLink<T>>();
            }

            public Builder addLink(T source, T target)
            {
                bool containsLink = false;
                foreach (GraphLink<T> link in links)
                {
                    if (link.Source.Equals(source) && link.Target.Equals(target))
                    {
                        containsLink = true;
                    }
                }

                if (containsLink == false)
                {
                    GraphNode<T>.Builder sourceNode = addOrGetNode(source);
                    GraphNode<T>.Builder targetNode = addOrGetNode(target);
                    links.Add(new GraphLink<T>.Builder().withSource(source).withTarget(target).build());
                    sourceNode = sourceNode.withOutgoingLink(target);
                    targetNode = targetNode.withIncomingLink(source);

                }
                return this;
            }

            public Graph<T> build()
            {
                return new Graph<T>(
                    new Dictionary<T, GraphNode<T>>(idNodeMap.ToDictionary(
                        kvp1 => kvp1.Key, kvp2 => kvp2.Value.build())),
                    links);
            }

            private GraphNode<T>.Builder addOrGetNode(T id)
            {
                bool contains = false;
                foreach(T k in idNodeMap.Keys){
                    if(k.Equals(id)){
                        contains = true;
                    }
                }
                if (contains == false)
                {
                    GraphNode<T>.Builder node = new GraphNode<T>.Builder().withID(id);
                    idNodeMap.Add(id, node);
                    return node;
                }
                foreach(T key in idNodeMap.Keys){
                    if(key.Equals(id)){
                        GraphNode<T>.Builder node = idNodeMap[key];
                        return node;
                    }
                }
                return null;
            }
        }
    }


}
