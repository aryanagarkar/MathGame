using NUnit.Framework;
using System.Collections.Generic;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class KnowlegeStateTests
    {
        [Test]
        public void TestGenerateFringeState()
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

            List<string> fringe = knowledgeState.Fringe;

            //Expectations

            //Test and assert
            Assert.IsTrue(fringe.Contains("B"));
            Assert.IsTrue(fringe.Contains("C"));
        }
    }
}