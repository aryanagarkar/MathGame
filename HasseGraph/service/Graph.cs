﻿using Service.Util;
using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class Graph
    {
        readonly MDictionary<string, GraphNode> idNodeMap;
        List<GraphLink> links = new MList<GraphLink>();

        public Graph(MDictionary<string, GraphNode> idNodeMap, List<GraphLink> links)
        {
            this.idNodeMap = idNodeMap;
            this.links = links;
        }

        public MDictionary<string, GraphNode> IdNodeMap
        {
            get { return idNodeMap; }
        }

        public List<GraphNode> Nodes{
            get{return idNodeMap.Values.ToList(); }
        }

        public  List<GraphLink> Links{
            get{return links; }
        }
    }
}