using Service.Util;
using System.Collections.Generic;

namespace service
{
    public class GraphBuilder
    {
        MDictionary<string, GraphNode> idNodeMap = new MDictionary<string, GraphNode>();
        MList<GraphLink> links = new MList<GraphLink>();

        public GraphBuilder() { }

        public GraphBuilder addLink(string id1, string id2)
        {
            GraphNode nodeId1 = addOrGetNode(id1);
            GraphNode nodeId2 = addOrGetNode(id2);
            bool duplicate = false;
            foreach (GraphLink link in links)
            {
                if (link.Source.Equals(nodeId1) && link.Target.Equals(nodeId2))
                {
                    duplicate = true;
                }
            }

            if(duplicate == false){
                links.AddItem(new GraphLink(nodeId1, nodeId2));
                nodeId1.OutgoingLinks.AddItem(nodeId2);
                nodeId2.IncomingLinks.AddItem(nodeId1);
            }
            
            return this;
        }

        public Graph build()
        {
            return new Graph(idNodeMap, links);
        }

        private GraphNode addOrGetNode(string id)
        {
            if (!idNodeMap.ContainsKey(id))
            {
                GraphNode node = new GraphNode();
                idNodeMap.Add(id, node);
            }
            return idNodeMap[id];
        }
    }
}
