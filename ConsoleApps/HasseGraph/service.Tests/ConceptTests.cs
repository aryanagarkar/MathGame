using NUnit.Framework;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class ConceptTests
    {
        [Test]
        public void testConceptEquals()
        {
            //Setup
            Concept actualConcept = createDefaultConcept();

            //Expectations
            Concept expected = new Concept("B");

            //Test and assert
            Assert.IsTrue(actualConcept.Equals(expected));
        }

        private Concept createDefaultConcept()
        {
            Concept c = new Concept("B");
            return c;
        }
    }
}