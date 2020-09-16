using NUnit.Framework;
using System.Collections.Generic;
using Service.Util;

namespace service.Tests
{
    [TestFixture]
    public class SaveAndLoadStoryTests
    {
        string path = "../../../SampleStoryGraph.json";

        [Test]
        public void testLoadedStoryGraphNodes()
        {
            // Data setup
                        
            // Expectations
            Graph expected = new Graph();

            GraphNode node1 = new GraphNode();
            List<string> node1Conversations = new List<string>();
            node1Conversations.Add("Hello");
            MDictionary<string, List<string>> node1Links = new MDictionary<string, List<string>>();
            List<string> node1LinkedIds = new List<string>();
            node1LinkedIds.Add("start");
            node1Links.Add(AnnotationEnum.failure.ToString(), node1LinkedIds);
            
            node1.links = node1Links;
            node1.character = CharacterTypeEnum.Troll.ToString();
            node1.conversations = node1Conversations;

            GraphNode startNode = new GraphNode();
            List<string> startNodeConversations = new List<string>();
            startNodeConversations.Add("Hello");

            MDictionary<string, List<string>> startNodeLinks = new MDictionary<string, List<string>>();
            List<string> startNodeLinkedIds = new List<string>();
            startNodeLinkedIds.Add("1");
            startNodeLinks.Add(AnnotationEnum.success.ToString(), startNodeLinkedIds);
            
            startNode.links = startNodeLinks;
            startNode.character = CharacterTypeEnum.Wizard.ToString();
            startNode.conversations = startNodeConversations;


            MDictionary<string, GraphNode> nodes = new MDictionary<string, GraphNode>();
            nodes.Add("1", node1);
            nodes.Add("start", startNode);

            expected.nodes = nodes;

            // Test and Assert
            Graph loaded = SaveAndLoadStory.loadStory(path);
            Assert.AreEqual(loaded, expected);
        }
    }
}