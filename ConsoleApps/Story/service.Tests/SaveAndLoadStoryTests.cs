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
        public void testLoadedStoryGraphNodes_equalToExpectedGraphNodes()
        {
            // Data setup
                        
            // Expectations
            Graph expected = new Graph();

            expected.Nodes.Add("1", createNode(CharacterTypeEnum.Troll, "Hello", AnnotationEnum.Failure, "start"));
            expected.Nodes.Add("start", createNode(CharacterTypeEnum.Wizard, "Hello", AnnotationEnum.Success, "1"));

            // Test and Assert
            Graph loaded = SaveAndLoadStory.loadStory(path);
            Assert.AreEqual(loaded, expected);
        }

         [Test]
        public void testLoadedStoryGraphNodes_NotqualToExpectedGraphNodes()
        {
            // Data setup
                        
            // Expectations
            Graph expected = new Graph();

            expected.Nodes.Add("start", createNode(CharacterTypeEnum.Troll, "Hello", AnnotationEnum.Failure, "start"));
            expected.Nodes.Add("1", createNode(CharacterTypeEnum.Wizard, "Hello", AnnotationEnum.Success, "1"));

            // Test and Assert
            Graph loaded = SaveAndLoadStory.loadStory(path);
            Assert.AreNotEqual(loaded, expected);
        }

        private GraphNode createNode(CharacterTypeEnum character, List<string> conversations, MDictionary<string, List<string>> links){
            GraphNode node = new GraphNode();

            node.Links = links;
            StoryElement element = new StoryElement();
            element.Character = character.ToString();
            element.Conversations = conversations;
            // node.Character = character.ToString();
            // node.Conversations = conversations;

            return node;
        }

        private GraphNode createNode(CharacterTypeEnum character, string sentence, AnnotationEnum annotation, string linkedNodeID){
            GraphNode node = new GraphNode();

            List<string> conversations = new List<string>();
            conversations.Add(sentence);

            List<string> linkedIds = new List<string>();
            linkedIds.Add(linkedNodeID);
            MDictionary<string, List<string>> nodeLinks = new MDictionary<string, List<string>>();
            nodeLinks.Add(annotation.ToString(), linkedIds);

            node = createNode(character, conversations, nodeLinks);

            return node;
        }
    }
}