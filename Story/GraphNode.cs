using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class GraphNode
    {
        public string character { get; set; }
        public List<string> conversations { get; set; }
        public Dictionary<string, List<string>> links { get; set; }

        // public GraphNode(CharacterTypeEnum character, List<String> conversations, Dictionary<string, List<string>> links){
        //     this.character = character.ToString();
        //     this.conversations = conversations;
        //     this.links = links;
        // }

        public GraphNode() { }

        public override bool Equals(object obj)
        {
            if(obj == null){
                return false;
            }
            GraphNode node = obj as GraphNode;
            if(links.Count == node.links.Count){
                for(int i = 0; i < links.Count; i++){
                    string key = links.Keys.ElementAt(i);
                    if(node.links[key] == null) {
                        return false;
                    }
                    if(!links[key].SequenceEqual(node.links[key])) {
                        return false;
                    }
                }
            }
            return character.Equals(node.character) && conversations.SequenceEqual(node.conversations);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
