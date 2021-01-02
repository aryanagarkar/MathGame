using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.Serialization;

namespace Story
{
    [DataContract]
    [System.Serializable]
    public class StoryElement
    {
        [DataMember]
        public string Character { get; set; }
        [DataMember]
        public List<string> Conversations { get; set; }

        public StoryElement()
        {
            Conversations = new List<string>();
        }

        public override bool Equals(object obj)
        {
            StoryElement element = (StoryElement)obj;
            return Character.Equals(element.Character)
             && Conversations.SequenceEqual(element.Conversations);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
