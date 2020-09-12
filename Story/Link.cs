using System;
using System.Collections.Generic;

namespace service
{
    public class Link
    {
        GraphNode startNode;
        GraphNode endNode;

        AnnotationEnum annotation;
        bool activated;

        public Link(GraphNode StartNode, GraphNode endNode, AnnotationEnum annotation){
            this.startNode = StartNode;
            this.endNode = endNode;
            this.annotation = annotation;
            activated = false;
        }

        public GraphNode StartNode{
            get{return startNode; }
        }

        public GraphNode EndNode{
            get{return endNode; }
        }

        public AnnotationEnum Annotation{
            get{return annotation; }
        }

        public void activate(){
            activated = true;
        }

        public void deactivate(){
            activated = false;
        }
    }
}
