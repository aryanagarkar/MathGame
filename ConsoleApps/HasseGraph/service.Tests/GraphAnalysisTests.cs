using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class GraphAnalysisTests
    {
        [Test]
        public void testTopologicalSort_NoCycles()
        {
            //Setup
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .addLink("B", "C")
                    .addLink("C", "D")
                    .addLink("D", "E")
                    .build();
            GraphAnalysis analysis = new GraphAnalysis(graph);

            //Expectations
            List<GraphNode> expected = new List<GraphNode>();
            expected.Add(graph.IdNodeMap["A"]);
            expected.Add(graph.IdNodeMap["B"]);
            expected.Add(graph.IdNodeMap["C"]);
            expected.Add(graph.IdNodeMap["D"]);
            expected.Add(graph.IdNodeMap["E"]);

            //Test and assert
            Assert.IsTrue(analysis.SortedNodes.SequenceEqual(expected));
        }

        [Test]
        public void testTopologicalSort_OneCycle()
        {
            //Setup

            //Expectations

            //Test and assert
            try{
                Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .addLink("B", "C")
                    .addLink("C", "A")
                    .addLink("C", "D")
                    .addLink("A", "C")
                    .build();


            GraphAnalysis analysis = new GraphAnalysis(graph);
            IList<GraphNode> sortedNodes = analysis.SortedNodes;
            }

            catch(Exception e){
                 Assert.IsTrue(e.Message.Equals("Graph is cyclic"));
            }
        }

        [Test]
        public void testTopologicalSort_TwoConnectedSubgraphsWithCycles()
        {
            //Setup

            //Expectations

            //Test and assert
            try{
                Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .addLink("B", "C")
                    .addLink("C", "A")
                    .addLink("D", "E")
                    .addLink("E", "F")
                    .addLink("F", "D")
                    .addLink("B", "F")
                    .build();


            GraphAnalysis analysis = new GraphAnalysis(graph);
            IList<GraphNode> sortedNodes = analysis.SortedNodes;
            }

            catch(Exception e){
                 Assert.IsTrue(e.Message.Equals("Graph is cyclic"));
            }
        }

        [Test]
        public void testIsHesse()
        {
            //Setup
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .addLink("B", "C")
                    .addLink("B", "D")
                    .addLink("C", "E")
                    .build();
            GraphAnalysis analysis = new GraphAnalysis(graph);

            //Expectations

            //Test and assert
            Assert.IsTrue(analysis.IsHesse);
        }

         [Test]
        public void testIsNotHesse()
        {
            //Setup
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .addLink("B", "C")
                    .addLink("A", "C")
                    .build();
            GraphAnalysis analysis = new GraphAnalysis(graph);

            //Expectations

            //Test and assert
            Assert.IsFalse(analysis.IsHesse);
        }
    }
}