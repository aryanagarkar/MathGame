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
            //setUp
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .build();

            List<KnowlegeState> states = L.AllPossibleStates;

            //Expectations
            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(conceptA);

            HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(conceptA);
            state2.Add(conceptB);

            //test and assert
            Assert.IsTrue(states.Contains(new KnowlegeState()));
            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));
        }

        [Test]
        public void testGeneratePossibleStates_oneConceptLinkedToTwo()
        {
            //setUp
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptB)
                              .withLink(conceptA, conceptC)
                              .build();

            List<KnowlegeState> states = L.AllPossibleStates;

            //expectations
            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(conceptA);

            HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(conceptA);
            state2.Add(conceptB);

            HashSet<Concept> state3 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptB);
            state3.Add(conceptC);

            HashSet<Concept> state4 = new HashSet<Concept>();
            state4.Add(conceptA);
            state4.Add(conceptB);

            HashSet<Concept> state5 = new HashSet<Concept>();
            state5.Add(conceptA);
            state5.Add(conceptC);

            //test and assert
            Assert.IsTrue(states.Contains(new KnowlegeState()));
            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state3)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state4)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state5)));
        }

        [Test]
        public void testGeneratePossibleStates_twoRoots()
        {
            //setUp
            Concept conceptA = new Concept("A");
            Concept conceptB = new Concept("B");
            Concept conceptC = new Concept("C");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(conceptA, conceptC)
                              .withLink(conceptB, conceptC)
                              .build();

            List<KnowlegeState> states = L.AllPossibleStates;

            //Expectations
            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(conceptA);

            HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(conceptB);

            HashSet<Concept> state3 = new HashSet<Concept>();
            state3.Add(conceptA);
            state3.Add(conceptB);
            state3.Add(conceptC);

            HashSet<Concept> state4 = new HashSet<Concept>();
            state4.Add(conceptA);
            state4.Add(conceptB);

            HashSet<Concept> state5 = new HashSet<Concept>();
            state5.Add(conceptB);
            state5.Add(conceptC);

            HashSet<Concept> state6 = new HashSet<Concept>();
            state6.Add(conceptA);
            state6.Add(conceptC);

            //test and assert
            Assert.IsTrue(states.Contains(new KnowlegeState()));
            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state3)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state4)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state5)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state6)));
        }

        [Test]
        public void testGeneratePossibleStates_GraphFromPaper()
        {
            //setUp
            Concept A = new Concept("A");
            Concept B = new Concept("B");
            Concept C = new Concept("C");
            Concept D = new Concept("D");
            Concept E = new Concept("E");
            Concept F = new Concept("F");
            Concept G = new Concept("G");
            Concept H = new Concept("H");

            LearningSpace L = new LearningSpace.Builder()
                              .withLink(A, C)
                              .withLink(A, D)
                              .withLink(B, D)
                              .withLink(C, E)
                              .withLink(D, F)
                              .withLink(E, G)
                              .withLink(F, H)
                              .withLink(F, G)
                              .build();

            List<KnowlegeState> states = L.AllPossibleStates;

            //Expectations
            HashSet<Concept> state1 = new HashSet<Concept>();
            state1.Add(A);

            HashSet<Concept> state2 = new HashSet<Concept>();
            state2.Add(B);

            HashSet<Concept> state3 = new HashSet<Concept>();
            state3.Add(A);
            state3.Add(B);

            HashSet<Concept> state4 = new HashSet<Concept>();
            state4.Add(A);
            state4.Add(C);

            HashSet<Concept> state5 = new HashSet<Concept>();
            state5.Add(A);
            state5.Add(B);
            state5.Add(C);

            HashSet<Concept> state6 = new HashSet<Concept>();
            state6.Add(A);
            state6.Add(B);
            state6.Add(C);
            state6.Add(D);

            HashSet<Concept> state7 = new HashSet<Concept>();
            state7.Add(A);
            state7.Add(B);
            state7.Add(D);

            HashSet<Concept> state8 = new HashSet<Concept>();
            state8.Add(A);
            state8.Add(C);
            state8.Add(E);

            HashSet<Concept> state9 = new HashSet<Concept>();
            state9.Add(A);
            state9.Add(B);
            state9.Add(C);
            state9.Add(E);

            HashSet<Concept> state10 = new HashSet<Concept>();
            state10.Add(A);
            state10.Add(B);
            state10.Add(C);
            state10.Add(D);
            state10.Add(E);

            HashSet<Concept> state11 = new HashSet<Concept>();
            state11.Add(A);
            state11.Add(B);
            state11.Add(D);
            state11.Add(F);

            HashSet<Concept> state12 = new HashSet<Concept>();
            state12.Add(A);
            state12.Add(B);
            state12.Add(C);
            state12.Add(D);
            state12.Add(F);

            HashSet<Concept> state13 = new HashSet<Concept>();
            state13.Add(A);
            state13.Add(B);
            state13.Add(C);
            state13.Add(D);
            state13.Add(E);
            state13.Add(F);

            HashSet<Concept> state14 = new HashSet<Concept>();
            state14.Add(A);
            state14.Add(B);
            state14.Add(D);
            state14.Add(F);
            state14.Add(H);

            HashSet<Concept> state15 = new HashSet<Concept>();
            state15.Add(A);
            state15.Add(B);
            state15.Add(C);
            state15.Add(D);
            state15.Add(F);
            state15.Add(H);

            HashSet<Concept> state16 = new HashSet<Concept>();
            state16.Add(A);
            state16.Add(B);
            state16.Add(C);
            state16.Add(D);
            state16.Add(E);
            state16.Add(F);
            state16.Add(G);

            HashSet<Concept> state17 = new HashSet<Concept>();
            state17.Add(A);
            state17.Add(C);
            state17.Add(B);
            state17.Add(D);
            state17.Add(E);
            state17.Add(F);
            state17.Add(H);

            HashSet<Concept> state18 = new HashSet<Concept>();
            state18.Add(A);
            state18.Add(B);
            state18.Add(C);
            state18.Add(D);
            state18.Add(E);
            state18.Add(F);
            state18.Add(G);
            state18.Add(H);

            //Test and assert
            Assert.IsTrue(states.Contains(new KnowlegeState()));
            Assert.IsTrue(states.Contains(new KnowlegeState(state1)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state2)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state3)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state4)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state5)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state6)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state7)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state8)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state9)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state10)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state11)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state12)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state13)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state14)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state15)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state16)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state17)));
            Assert.IsTrue(states.Contains(new KnowlegeState(state18)));
        }
    }
}
