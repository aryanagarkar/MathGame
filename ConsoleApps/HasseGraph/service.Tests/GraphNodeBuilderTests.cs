using NUnit.Framework;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class GraphNodeBuilderTests
    {
        [Test]
        public void testNodeID()
        {
            //Setup
            GraphNode<Concept> expectedNode = createDefaultGraphNode();

            //Expectations

            //Test and assert
            Assert.AreEqual(new Concept("A"), expectedNode.Identity);
        }

        [Test]
        public void testNodeLinks()
        {
            //Setup
            GraphNode<Concept> expectedNode = createDefaultGraphNode();

            //Expectations

            //Test and assert
            Assert.IsTrue(expectedNode.IncomingLinks.Contains(new Concept("C")));
            Assert.IsTrue(expectedNode.IncomingLinks.Contains(new Concept("D")));
            Assert.IsTrue(expectedNode.OutgoingLinks.Contains(new Concept("B")));
            Assert.IsTrue(expectedNode.OutgoingLinks.Contains(new Concept("E")));
        }

        private GraphNode<Concept> createDefaultGraphNode()
        {
            GraphNode<Concept> node = new GraphNode<Concept>.Builder()
                    .withID(new Concept("A"))
                    .withIncomingLink(new Concept("C"))
                    .withIncomingLink(new Concept("D"))
                    .withOutgoingLink(new Concept("B"))
                    .withOutgoingLink(new Concept("E"))
                    .build();

            return node;
        }
    }
}