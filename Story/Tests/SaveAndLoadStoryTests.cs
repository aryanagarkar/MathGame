using NUnit.Framework;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

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
            Dictionary<string, List<string>> node1Links = new Dictionary<string, List<string>>();
            List<string> node1LinkedIds = new List<string>();
            node1LinkedIds.Add("start");
            node1Links.Add(AnnotationEnum.failure.ToString(), node1LinkedIds);
            
            node1.links = node1Links;
            node1.character = CharacterTypeEnum.Troll.ToString();
            node1.conversations = node1Conversations;

            GraphNode startNode = new GraphNode();
            List<string> startNodeConversations = new List<string>();
            startNodeConversations.Add("Hello");

            Dictionary<string, List<string>> startNodeLinks = new Dictionary<string, List<string>>();
            List<string> startNodeLinkedIds = new List<string>();
            startNodeLinkedIds.Add("1");
            startNodeLinks.Add(AnnotationEnum.success.ToString(), startNodeLinkedIds);
            
            startNode.links = startNodeLinks;
            startNode.character = CharacterTypeEnum.Wizard.ToString();
            startNode.conversations = startNodeConversations;

            

            Dictionary<string, GraphNode> nodes = new Dictionary<string, GraphNode>();
            nodes.Add("1", node1);
            nodes.Add("start", startNode);

            expected.nodes = nodes;

            // Test and Assert
            Graph loaded = SaveAndLoadStory.loadStory(path);
            Assert.AreEqual(loaded, expected);
        }
    }
}