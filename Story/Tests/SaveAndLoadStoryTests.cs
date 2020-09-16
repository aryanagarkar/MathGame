using NUnit.Framework;
using System.Collections.Generic;
using Service.Util;

namespace service.Tests
{
    [TestFixture]
    public class SaveAndLoadStoryTests
    {
        string path = "../../../SampleStoryGraph.json";

        private GraphNode createNode(CharacterTypeEnum character, List<string> conversations, MDictionary<string, List<string>> links){
            GraphNode node = new GraphNode();
            node.Links = links;
            node.Character = character.ToString();
            node.Conversations = conversations;
            return node;
        }

        [Test]
        public void testLoadedStoryGraphNodes()
        {
            // Data setup
                        
            // Expectations
            Graph expected = new Graph();

            GraphNode startNode;
            List<string> startNodeConversations = new List<string>();
            startNodeConversations.Add("Hello");

            MDictionary<string, List<string>> startNodeLinks = new MDictionary<string, List<string>>();
            List<string> startNodeLinkedIds = new List<string>();
            startNodeLinkedIds.Add("1");
            startNodeLinks.Add(AnnotationEnum.Success.ToString(), startNodeLinkedIds);

            startNode = createNode(CharacterTypeEnum.Wizard, startNodeConversations, startNodeLinks);

            GraphNode node1;
            List<string> node1Conversations = new List<string>();
            node1Conversations.Add("Hello");

            MDictionary<string, List<string>> node1Links = new MDictionary<string, List<string>>();
            List<string> node1LinkedIds = new List<string>();
            node1LinkedIds.Add("start");
            node1Links.Add(AnnotationEnum.Failure.ToString(), node1LinkedIds);
            
            node1 = createNode(CharacterTypeEnum.Troll, node1Conversations, node1Links);

            MDictionary<string, GraphNode> nodes = new MDictionary<string, GraphNode>();
            nodes.Add("1", node1);
            nodes.Add("start", startNode);

            expected.Nodes = nodes;

            // Test and Assert
            Graph loaded = SaveAndLoadStory.loadStory(path);
            Assert.AreEqual(loaded, expected);
        }
    }
}