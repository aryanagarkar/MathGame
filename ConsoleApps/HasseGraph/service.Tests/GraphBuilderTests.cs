using NUnit.Framework;
using System;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class GraphBuilderTests
    {
        [Test]
        public void TestNumOfNodes()
        {
            //Setup
            Graph graph = createDefaultGraph();

            //Expectations
            int numNodes = 4;


            //Test and assert
            Assert.AreEqual(numNodes, graph.Nodes.Count);
        }

        [Test]
        public void TestGraph_AllNodesAndLinksPresent()
        {
            //Setup
            Graph graph = createDefaultGraph();

            //Expectations

            //Test and assert
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("B"));
            Assert.IsTrue(graph.IdNodeMap["B"].OutgoingLinks.Contains("C"));
            Assert.IsTrue(graph.IdNodeMap["B"].OutgoingLinks.Contains("D"));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("C"));
            Assert.IsTrue(graph.IdNodeMap["C"].IncomingLinks.Contains("B"));
            Assert.IsTrue(graph.IdNodeMap["C"].OutgoingLinks.Contains("E"));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("D"));
            Assert.IsTrue(graph.IdNodeMap["D"].IncomingLinks.Contains("B"));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey("E"));
            Assert.IsTrue(graph.IdNodeMap["E"].IncomingLinks.Contains("C"));
        }

        [Test]
        public void TestGraph_AllLinksPresent()
        {
            //Setup
            Graph graph = createDefaultGraph();

            //Expectations

            //Test and assert
            Assert.IsTrue(graph.Links.Count == 3);
            Assert.IsTrue(graph.Links[0].Source.Equals("B"));
            Assert.IsTrue(graph.Links[0].Target.Equals("C"));
            Assert.IsTrue(graph.Links[1].Source.Equals("B"));
            Assert.IsTrue(graph.Links[1].Target.Equals("D"));
            Assert.IsTrue(graph.Links[2].Source.Equals("C"));
            Assert.IsTrue(graph.Links[2].Target.Equals("E"));
        }

        [Test]
        public void TestGraph_DuplicateLinkError()
        {
            try{
                Graph graph = new Graph.Builder()
                .addLink("B", "C")
                .addLink("B", "C")
                .build();
            }
            catch(InvalidOperationException e){
                Assert.IsTrue(e.Message.Contains("Cannot add duplicate node"));
            }
        }

        private Graph createDefaultGraph()
        {
            Graph graph = new Graph.Builder()
                    .addLink("B", "C")
                    .addLink("B", "D")
                    .addLink("C", "E")
                    .build();

            return graph;
        }
    }
}