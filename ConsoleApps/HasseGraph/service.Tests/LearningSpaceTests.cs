using NUnit.Framework;
using System.Collections.Generic;
using Service.graph;
using System;
using System.Linq;

namespace Service.tests
{
    [TestFixture]
    public class LearningSpaceTests
    {
        [Test]
        public void testEquals()
        {
            //Expectations
            Graph graph = new Graph.Builder()
                    .addLink("A", "B")
                    .build();

            KnowledgeState currentState = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("A")
                                        .build();

            LearningSpace ls = new LearningSpace(graph, currentState);

            LearningSpace expected = new LearningSpace(graph, currentState);

            //Test and assert
            Assert.IsTrue(ls.Equals(expected));
        }

        [Test]
        public void testSetUpAndGenerateLearningSpace()
        {
            //Expectations
            Graph graph = new Graph.Builder()
                   .addLink("A", "B")
                   .build();

            KnowledgeState currentState = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("A")
                                        .build();

            LearningSpace space = new LearningSpace(graph, currentState);
            List<KnowledgeState> learningSpace = space.setupAndGenerateLearningSpace();

            List<KnowledgeState> expected = new List<KnowledgeState>();


            KnowledgeState emptyState = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .build();

            KnowledgeState state1 = new KnowledgeState.Builder()
            .withGraph(graph)
            .withConcept("A")
            .withConcept("B")
            .build();

            KnowledgeState state2 = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("A")
                                        .build();

            KnowledgeState state3 = new KnowledgeState.Builder()
                                        .withGraph(graph)
                                        .withConcept("B")
                                        .build();

            expected.Add(emptyState);
            expected.Add(state1);
            expected.Add(state2);
            expected.Add(state3);

            //Test and assert
            Assert.IsTrue(learningSpace.SequenceEqual(expected));
        }
    }
}