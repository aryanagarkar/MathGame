using NUnit.Framework;

namespace service.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void TestGraph_NumOfNodesSameAsNumberOfConcepts()
        {
            //Setup
            Graph graph = createDefaultGraph();

            //Expectations
            int numConcepts = 4;

            //Test and assert
            Assert.AreEqual(graph.Nodes.Count, numConcepts);
        }
        public void TestGraph_AllNodesPresent()
        {
            //Setup
            Graph graph = createDefaultGraph();

            //Expectations

            //Test and assert
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("B"));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("C"));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("D"));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("E"));
        }
        private Graph createDefaultGraph()
        {
            Graph graph = new GraphBuilder()
                    .addLink("B", "C")
                    .addLink("B", "D")
                    .addLink("C", "E")
                    .build();

            return graph;
        }
    }
}