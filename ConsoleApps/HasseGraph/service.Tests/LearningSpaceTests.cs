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
        public void testGenerateRecentlyLearnedConcepts()
        {
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
        public void testGenerateLearnableConcepts()
        {
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
        public void testGeneratePossibleStates()
        {
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .build();

            List<KnowlegeState> states = L.setUpAndgeneratePossibleStates();

            Assert.IsTrue(states.Contains(new KnowlegeState()));

            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(conceptA);

            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));

            HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(conceptA);
            state2.Add(conceptB);

            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));
        }

        [Test]
        public void testGeneratePossibleStates_oneConceptLinkedToTwo()
        {
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .withLink(conceptA, conceptC)
                              .build();

            List<KnowlegeState> states = L.setUpAndgeneratePossibleStates();

            Assert.IsTrue(states.Contains(new KnowlegeState()));

            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(conceptA);

            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));

             HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(conceptA);
            state2.Add(conceptB);

            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));


            HashSet<Concept> state3 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptB);
            state3.Add(conceptC);

            Assert.IsTrue(states.Contains(new KnowlegeState(state3)));

            HashSet<Concept> state4 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptB);

            Assert.IsTrue(states.Contains(new KnowlegeState(state4)));

            HashSet<Concept> state5 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptC);

            Assert.IsTrue(states.Contains(new KnowlegeState(state5)));
        }

        [Test]
        public void testGeneratePossibleStates_oneRoots()
        {
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptC)
                              .withLink(conceptB, conceptC)
                              .build();

            List<KnowlegeState> states = L.setUpAndgeneratePossibleStates();

            Assert.IsTrue(states.Contains(new KnowlegeState()));

            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(conceptA);

            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));

            HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(conceptB);

            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));


            HashSet<Concept> state3 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptB);
            state3.Add(conceptC);

            Assert.IsTrue(states.Contains(new KnowlegeState(state3)));

            HashSet<Concept> state4 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptC);

            Assert.IsTrue(states.Contains(new KnowlegeState(state4)));

            HashSet<Concept> state5 = new HashSet<Concept>();
            state3.Add(conceptB);
            state3.Add(conceptC);

            Assert.IsTrue(states.Contains(new KnowlegeState(state5)));
        }
    }
}