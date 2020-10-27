using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

using Service.graph;

namespace Service.tests
{
    [TestFixture]
    public class LearrningSpaceTests
    {
        [Test]
        public void testGenerateRecentlyLearnedConcepts(){
            //Setup
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .withLink(conceptB, conceptC)
                              .build();

            L.addLearnedConcept(conceptA);
            L.addLearnedConcept(conceptB);

            List<Concept> actual = L.getRecentlyLearnedConcepts();

            //Expectations
            List<Concept> expected = new List<Concept>();
            expected.Add(conceptB);

            //Test and assert
            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [Test]
        public void testGenerateLearnableConcepts(){
            //Setup
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .withLink(conceptB, conceptC)
                              .build();

            L.addLearnedConcept(conceptA);
            L.addLearnedConcept(conceptB);

            List<Concept> actual = L.getLearnableConcepts();

            //Expectations
            List<Concept> expected = new List<Concept>();
            expected.Add(conceptC);

            //Test and assert
            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [Test]
        public void testGeneratePossibleStates(){
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .build();

            List<KnowlegeState> states = L.setUpAndgeneratePossibleStates();

            Assert.IsTrue(states.Contains(new KnowlegeState.Builder().build()));
            Assert.IsTrue(states.Contains(new KnowlegeState.Builder().
            withConcept(conceptA).withConcept(conceptB).build()));
            Assert.IsTrue(states.Contains(new KnowlegeState.Builder().withConcept(conceptA).build()));
        }
    }
}