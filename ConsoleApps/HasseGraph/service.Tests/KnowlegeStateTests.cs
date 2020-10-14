using NUnit.Framework;
using System.Collections.Generic;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class KnowlegeStateTests
    {
        [Test]
        public void testEquals()
        {
            //Expectations
            Graph graph = new Graph.Builder()
                        .addLink("A", "B")
                        .build();

            KnowledgeState state = new KnowledgeState.Builder()
                                            .withGraph(graph)
                                            .withConcept("A")
                                            .build();

            KnowledgeState expected = new KnowledgeState.Builder()
                                            .withGraph(graph)
                                            .withConcept("A")
                                            .build();

            //Test and assert
            Assert.IsTrue(state.Equals(expected));
        }

        [Test]
        public void testGenerateFringeState_outerAndInnerFringe()
        {
            //Setup
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .addLink("B", "C")
                    .addLink("C", "D")
                    .build();

            KnowledgeState knowledgeState = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("A")
                                        .withConcept("B")
                                        .build();

            HashSet<string> fringe = knowledgeState.Fringe;

            //Expectations

            //Test and assert
            Assert.IsTrue(fringe.Contains("B"));
            Assert.IsTrue(fringe.Contains("C"));
        }

         [Test]
        public void testGenerateFringeState_noInnerFringe()
        {
            //Setup
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .build();

            KnowledgeState knowledgeState = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("A")
                                        .build();

            HashSet<string> fringe = knowledgeState.Fringe;

            //Expectations

            //Test and assert
            Assert.IsTrue(fringe.Contains("B"));
        }

        [Test]
        public void testGenerateFringeState_noOuterFringe()
        {
            //Setup
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .build();

            KnowledgeState knowledgeState = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("A")
                                        .withConcept("B")
                                        .build();

            HashSet<string> fringe = knowledgeState.Fringe;

            //Expectations

            //Test and assert
            Assert.IsTrue(fringe.Contains("B"));
        }
    }
}