using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.Serialization;

namespace Story
{
    [DataContract]
    [System.Serializable]
    public class GraphLink
    {
        [DataMember]
        public string Annotation { get; set; }
        [DataMember]
        public List<string> Targets { get; set; }

        public GraphLink()
        {
            Targets = new List<string>();
        }

        public override bool Equals(object obj)
        {
            GraphLink other = (GraphLink)obj;
            return Annotation.Equals(other.Annotation)
             && Targets.SequenceEqual(other.Targets);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
