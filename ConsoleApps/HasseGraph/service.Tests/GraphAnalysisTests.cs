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
            Concept conceptA = new Concept("A");
            Concept conceeptB = new Concept("B");
            Concept conceptC = new Concept("C");
            Concept conceptD = new Concept("D");
            Concept conceptE = new Concept("E");

            Graph<Concept> graph = new Graph<Concept>.Builder()
                    .addLink(conceptA, conceeptB)
                    .addLink(conceeptB, conceptC)
                    .addLink(conceptC, conceptD)
                    .addLink(conceptD, conceptE)
                    .build();

            GraphAnalysis<Concept> analysis = new GraphAnalysis<Concept>(graph);

            //Expectations
            List<GraphNode<Concept>> expected = new List<GraphNode<Concept>>();
            expected.Add(graph.IdNodeMap[conceptA]);
            expected.Add(graph.IdNodeMap[conceeptB]);
            expected.Add(graph.IdNodeMap[conceptC]);
            expected.Add(graph.IdNodeMap[conceptD]);
            expected.Add(graph.IdNodeMap[conceptE]);

            //Test and assert
            Assert.IsTrue(analysis.SortedNodes.SequenceEqual(expected));
        }

        [Test]
        public void testIsCyclic_OneCycle()
        {
            //Setup
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");
            Concept conceptD = new Concept("D");

            Graph<Concept> graph = new Graph<Concept>.Builder()
                   .addLink(conceptA, conceptB)
                   .addLink(conceptB, conceptC)
                   .addLink(conceptC, conceptA)
                   .addLink(conceptC, conceptD)
                   .addLink(conceptA, conceptC)
                   .build();

            GraphAnalysis<Concept> analysis = new GraphAnalysis<Concept>(graph);

            //Expectations

            //Test and assert
            Assert.IsTrue(analysis.isCyclic());
        }

        [Test]
        public void testIsCyclic_TwoConnectedSubgraphsWithCycles()
        {
            //Setup
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");
            Concept conceptD = new Concept("D");
            Concept conceptE = new Concept("E");
            Concept conceptF = new Concept("F");

            Graph<Concept> graph = new Graph<Concept>.Builder()
                    .addLink(conceptA, conceptB)
                    .addLink(conceptB, conceptC)
                    .addLink(conceptC, conceptA)
                    .addLink(conceptD, conceptE)
                    .addLink(conceptE, conceptF)
                    .addLink(conceptF, conceptD)
                    .addLink(conceptB, conceptF)
                    .build();


            GraphAnalysis<Concept> analysis = new GraphAnalysis<Concept>(graph);

            //Expectations

            //Test and assert
            Assert.IsTrue(analysis.isCyclic());
        }

        [Test]
        public void testIsHesse()
        {
            //Setup
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");
            Concept conceptD = new Concept("D");
            Concept conceptE = new Concept("E");

            Graph<Concept> graph = new Graph<Concept>.Builder()
                    .addLink(conceptA, conceptB)
                    .addLink(conceptB, conceptC)
                    .addLink(conceptB, conceptD)
                    .addLink(conceptC, conceptE)
                    .build();

            GraphAnalysis<Concept> analysis = new GraphAnalysis<Concept>(graph);

            //Expectations

            //Test and assert
            Assert.IsTrue(analysis.isHesse());
        }

        [Test]
        public void testIsNotHesse()
        {
            //Setup
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            Graph<Concept> graph = new Graph<Concept>.Builder()
                    .addLink(conceptA, conceptB)
                    .addLink(conceptB, conceptC)
                    .addLink(conceptA, conceptC)
                    .build();
            GraphAnalysis<Concept> analysis = new GraphAnalysis<Concept>(graph);

            //Expectations

            //Test and assert
            Assert.IsFalse(analysis.isHesse());
        }
    }
}