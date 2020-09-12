using System;
using System.Collections.Generic;

namespace service
{
    public class Graph
    {
        List<GraphNode> nodes;
        List<Link> links;

        public Graph()
        {
            nodes = new List<GraphNode>();
            List<String> conversations = new List<String>();
            string sentence = new string("I will give you directions if you help me solve my problem");
            conversations.Add(sentence);

            GraphNode node1 = new GraphNode(CharacterTypeEnum.farmer, conversations);

            GraphNode node2 = new GraphNode(CharacterTypeEnum.troll, conversations);

            nodes.Add(node1);
            nodes.Add(node2);

            links = new List<Link>();
            links.Add(new Link(node1, node2, AnnotationEnum.success));
        }

        public List<GraphNode> Nodes
        {
            get { return nodes; }
        }

         public List<Link> Links
        {
            get { return links; }
        }
    }
}
