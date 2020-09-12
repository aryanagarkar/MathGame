using NUnit.Framework;
using service;
using System.Linq;

namespace service.Tests
{
    [TestFixture]
    public class SaveAndLoadStoryTests
    {
        string path = "/tmp/MyStoryData.data";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testLoadedStoryGraphNodesArsSameAsExpectedGraphNodes_storyGraphFileNotPreCreated()
        {
            Graph graph = new Graph();
            SaveAndLoadStory.saveStory(graph, path);
            Graph loadedGraph = SaveAndLoadStory.loadStory(path);

            Graph expected = new Graph();

            for(int i = 0; i < expected.Nodes.Count; i++){
                Assert.AreEqual(expected.Nodes[i].Conversations, loadedGraph.Nodes[i].Conversations);
                Assert.AreEqual(expected.Nodes[i].Character, loadedGraph.Nodes[i].Character);
            }
        }
    }
}