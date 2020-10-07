namespace Service
{
    public class GraphLink
    {
        Graph graph;
        string source;
        string target;

        GraphLink(Graph graph, string source, string target)
        {
            this.graph = graph;
            this.source = source;
            this.target = target;
        }

        public string Source
        { 
            get { return source; }
        }

        public string Target
        {
            get { return target; }
        }

        public override bool Equals(object obj)
        {
            GraphLink link = (GraphLink)obj;
            return source.Equals(link.Source) && target.Equals(link.target);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public class Builder
        {
            Graph graph;
            string source;
            string target;

            public Builder()
            {
            }

            public Builder withGraph(Graph graph)
            {
                this.graph = graph;
                return this;
            }
            public Builder withSource(string source)
            {
                this.source = source;
                return this;
            }

            public Builder withTarget(string target)
            {
                this.target = target;
                return this;
            }

            public GraphLink build()
            {
                return new GraphLink(graph, source, target);
            }
        }
    }


}
