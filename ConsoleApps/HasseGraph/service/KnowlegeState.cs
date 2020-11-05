using System.Collections.Generic;

namespace Service.graph
{
    public class KnowlegeState
    {
        readonly HashSet<Concept> concepts;

        public KnowlegeState(HashSet<Concept> concepts)
        {
            this.concepts = concepts;
        }

        public KnowlegeState(KnowlegeState state){
            this.concepts = state.concepts;
        }

        public KnowlegeState()
        {
            this.concepts = new HashSet<Concept>();
        }

         public HashSet<Concept> Concepts
        {
            get { return concepts; }
        }

        public override bool Equals(object obj)
        {
            KnowlegeState other = (KnowlegeState)obj;
            return concepts.SetEquals(other.concepts);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
