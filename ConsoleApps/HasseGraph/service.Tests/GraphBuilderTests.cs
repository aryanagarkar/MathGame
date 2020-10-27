using NUnit.Framework;
using System;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class GraphBuilderTests
    {
        [Test]
        public void testNumOfNodes()
        {
            //Setup
            Graph<Concept> graph = createDefaultGraph();

            //Expectations
            int numNodes = 4;

            //Test and assert
            Assert.AreEqual(numNodes, graph.Nodes.Count);
        }

        [Test]
        public void testGraph_AllNodesAndLinksPresent()
        {
            //Setup
            Graph<Concept> graph = createDefaultGraph();

            //Expectations

            //Test and assert
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");
            Concept conceptD = new Concept("D");
            Concept conceptE = new Concept("E");


            Assert.IsTrue(graph.IdNodeMap.Keys.Contains(conceptB));
            Assert.IsTrue(graph.IdNodeMap[conceptB]
            .OutgoingLinks.Contains(conceptC));
            Assert.IsTrue(graph.IdNodeMap[conceptB]
            .OutgoingLinks.Contains(conceptD));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey(conceptC));
            Assert.IsTrue(graph.IdNodeMap[conceptC]
            .IncomingLinks.Contains(conceptB));
            Assert.IsTrue(graph.IdNodeMap[conceptC]
            .OutgoingLinks.Contains(conceptE));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey(conceptD));
            Assert.IsTrue(graph.IdNodeMap[conceptD]
            .IncomingLinks.Contains(conceptB));
            Assert.IsTrue(graph.IdNodeMap.ContainsKey(conceptE));
            Assert.IsTrue(graph.IdNodeMap[conceptE]
            .IncomingLinks.Contains(conceptC));
        }

        [Test]
        public void testGraph_AllLinksPresent()
        {
            //Setup
            Graph<Concept> graph = createDefaultGraph();

            //Expectations

            //Test and assert
            Assert.IsTrue(graph.Links.Count == 3);
            Assert.IsTrue(graph.Links[0].Source.Equals(new Concept("B")));
            Assert.IsTrue(graph.Links[0].Target.Equals(new Concept("C")));
            Assert.IsTrue(graph.Links[1].Source.Equals(new Concept("B")));
            Assert.IsTrue(graph.Links[1].Target.Equals(new Concept("D")));
            Assert.IsTrue(graph.Links[2].Source.Equals(new Concept("C")));
            Assert.IsTrue(graph.Links[2].Target.Equals(new Concept("E")));
        }

        [Test]
        public void testGraph_DuplicateLinkError()
        {
            //Setup
            Graph<Concept> graph = new Graph<Concept>.Builder()
                .addLink(new Concept("B"), new Concept("C"))
                .addLink(new Concept("B"), new Concept("C"))
                .build();

            Assert.IsTrue(graph.Links.Count == 1);
            Assert.IsTrue(graph.Links[0].Source.Equals(new Concept("B")));
            Assert.IsTrue(graph.Links[0].Target.Equals(new Concept("C")));
        }

        private Graph<Concept> createDefaultGraph()
        {
            Graph<Concept> graph = new Graph<Concept>.Builder()
                    .addLink(new Concept("B"), new Concept("C"))
                    .addLink(new Concept("B"), new Concept("D"))
                    .addLink(new Concept("C"), new Concept("E"))
                    .build();

            return graph;
        }
    }
}