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
            GraphNode node = createDefaultGraphNode();

            //Expectations

            //Test and assert
            Assert.AreEqual("A", node.ID);
        }

        [Test]
        public void testNodeLinks(){
            //Setup
            GraphNode node = createDefaultGraphNode();

            //Expectations

            //Test and assert
            Assert.IsTrue(node.IncomingLinks.Contains("C"));
            Assert.IsTrue(node.IncomingLinks.Contains("D"));
            Assert.IsTrue(node.OutgoingLinks.Contains("B"));
            Assert.IsTrue(node.OutgoingLinks.Contains("E"));
        }

        private GraphNode createDefaultGraphNode()
        {
            GraphNode node = new GraphNode.Builder()
                    .withID("A")
                    .withIncomingLink("C")
                    .withIncomingLink("D")
                    .withOutgoingLink("B")
                    .withOutgoingLink("E")
                    .build();

            return node;
        }
    }
}