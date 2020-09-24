﻿using Service.Util;
using System.Collections.Generic;

namespace service
{
    public class GraphBuilder
    {
        MDictionary<string, GraphNode> idNodeMap = new MDictionary<string, GraphNode>();
        List<GraphLink> links = new MList<GraphLink>();

        public GraphBuilder()
        {  
        }

        GraphBuilder(List<GraphLink> links, MDictionary<string, GraphNode> idNodeMap){
            this.links = links;
            this.idNodeMap = idNodeMap;
        }

        public GraphBuilder addLink(string id1, string id2){
            GraphNode nodeId1 = addOrGetNode(id1);
            GraphNode nodeId2 = addOrGetNode(id2);
            links.Add(new GraphLink(nodeId1, nodeId2));
            
            nodeId1.OutgoingLinks.Add(nodeId2);
            nodeId2.IncomingLinks.Add(nodeId1);

            return this;
        }

        public Graph build(){
            return new Graph(idNodeMap, links);
        }

        private GraphNode addOrGetNode(string id){
            if(!idNodeMap.ContainsKey(id)){
                GraphNode node = new GraphNode();
                idNodeMap.Add(id, node);
            }
            return idNodeMap[id];
        }
    }
}