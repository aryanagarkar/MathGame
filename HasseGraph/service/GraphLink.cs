using System.Collections.Generic;

namespace service
{
    public class GraphLink
    {
        GraphNode source;
        GraphNode target;


        public GraphLink(GraphNode source, GraphNode target)
        {
            this.source = source;
            this.target = target;
        }

        public GraphNode Source
        {
            get { return source; }
        }

        public GraphNode Target
        {
            get { return target; }
        }
    }
}
