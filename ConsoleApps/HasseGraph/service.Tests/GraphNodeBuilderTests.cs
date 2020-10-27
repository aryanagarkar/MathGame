using NUnit.Framework;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class GraphNodeBuilderTests
    {
        [Test]
        public void testNodeID(){
            //Setup
            GraphNode<Concept> node = createDefaultGraphNode();

            //Expectations

            //Test and assert
            Assert.AreEqual(new Concept("A"), node.ID);
        }

        [Test]
        public void testNodeLinks(){
            //Setup
            GraphNode<Concept> node = createDefaultGraphNode();

            //Expectations

            //Test and assert
            Assert.IsTrue(node.IncomingLinks.Contains(new Concept("C")));
            Assert.IsTrue(node.IncomingLinks.Contains(new Concept("D")));
            Assert.IsTrue(node.OutgoingLinks.Contains(new Concept("B")));
            Assert.IsTrue(node.OutgoingLinks.Contains(new Concept("E")));
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