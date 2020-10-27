using NUnit.Framework;
using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class ConceptTests
    {
        [Test]
        public void testConceptEquals(){
            //Setup
            Concept actual = createDefaultConcept();

            //Expectations
            Concept expected = new Concept("B");

            //Test and assert
            Assert.IsTrue(actual.Equals(expected));
        }

        private Concept createDefaultConcept()
        {
            Concept c = new Concept("B");
            return c;
        }
    }
}