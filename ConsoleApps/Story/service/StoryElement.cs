using System.Collections.Generic;
using System.Linq;
using Service.Util;
using System;

namespace service
{
    public class StoryElement
    {
        public string Character { get; set; }
        public List<string> Conversations { get; set; }

        public StoryElement() {
            Conversations = new List<string>();
         }

        public override bool Equals(object obj){
            StoryElement other = (StoryElement)obj;
            return Character == other.Character && 
            Conversations.SequenceEqual(other.Conversations);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
