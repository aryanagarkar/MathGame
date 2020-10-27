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

        public class Builder
        {
            HashSet<Concept> concepts;

            public Builder()
            {
                concepts = new HashSet<Concept>();
            }

            public KnowlegeState.Builder withConcept(Concept c){
                this.concepts.Add(c);
                return this;       
            }

            public KnowlegeState build(){
                return new KnowlegeState(concepts);
            }
        }
    }
}
