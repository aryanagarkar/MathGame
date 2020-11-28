namespace Service.graph
{
    
    /*This is a generic graph link. It has a generic type source and target
    and is used in a graph of the same type.*/

    public class GraphLink<T>
    {
        Graph<T> graph;
        T source;
        T target;

        GraphLink(Graph<T> graph, T source, T target)
        {
            this.graph = graph;
            this.source = source;
            this.target = target;
        }

        public T Source
        {
            get { return source; }
        }

        public T Target
        {
            get { return target; }
        }

        public override bool Equals(object obj)
        {
            GraphLink<T> link = (GraphLink<T>) obj;
            return source.Equals(link.Source) && target.Equals(link.target);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public class Builder
        {
            Graph<T> graph;
            T source;
            T target;

            public Builder()
            {
            }

            public Builder withGraph(Graph<T> graph)
            {
                this.graph = graph;
                return this;
            }
            public Builder withSource(T source)
            {
                this.source = source;
                return this;
            }

            public Builder withTarget(T target)
            {
                this.target = target;
                return this;
            }

            public GraphLink<T> build()
            {
                return new GraphLink<T>(graph, source, target);
            }
        }
    }
}
