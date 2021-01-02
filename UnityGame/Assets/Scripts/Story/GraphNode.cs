using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Serialization;

namespace Story
{
    [DataContract]
    [System.Serializable]
    public class GraphNode
    {
        [DataMember]
        public string ID {get; set;}
           [DataMember]
        public StoryElement Element { get; set; }
           [DataMember]
        public List<GraphLink> Links { get; set; }


        public GraphNode() { 
            Links = new List<GraphLink>();
        }

        public override bool Equals(object obj)
        {
            GraphNode node = (GraphNode)obj;

            return ID.Equals(node.ID) && Element.Equals(node.Element)
            && Links.SequenceEqual(node.Links);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
