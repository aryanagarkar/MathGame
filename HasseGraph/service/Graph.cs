using Service.Util;
using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class Graph
    {
        readonly MDictionary<string, GraphNode> idNodeMap;
        readonly MList<GraphLink> links = new MList<GraphLink>();

        internal Graph(MDictionary<string, GraphNode> idNodeMap, MList<GraphLink> links)
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

        public  MList<GraphLink> Links{
            get{return links; }
        }
    }
}
