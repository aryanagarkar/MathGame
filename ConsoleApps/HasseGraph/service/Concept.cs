namespace Service.graph
{
    public class Concept
    {
        readonly string name;

        public Concept(string id)
        {
            this.name = id;
        }

        public string Name
        {
            get { return name; }
        }

        public override bool Equals(object obj)
        {
            Concept other = (Concept) obj;
            return name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }namespace Service.graph
{
    public class Concept
    {
        readonly string id;

        public Concept(string id)
        {
            this.id = id;
        }

        public string ID
        {
            get { return id; }
        }

        public override bool Equals(object obj)
        {
            Concept other = (Concept)obj;
            return id == other.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}

}
