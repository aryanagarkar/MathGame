using System;
using System.Collections.Generic;

namespace service
{
    public class GraphNode
    {
        CharacterTypeEnum character;
        List<String> conversations;

        public GraphNode(CharacterTypeEnum character, List<String> conversations){
            this.character = character;
            this.conversations = conversations;
        }

        public GraphNode(){
        }

        public IList<String> Conversations
        {
            get { return conversations.AsReadOnly(); }
        }

        public CharacterTypeEnum Character
        {
            get { return character; }
        }
        
        public void addConversation(String conversation)
        {
            if (!conversations.Contains(conversation))
            {
                conversations.Add(conversation);
            }
        }
    }
}
