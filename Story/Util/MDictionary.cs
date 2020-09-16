using System.Collections.Generic;
using System.Linq;

namespace Service.Util
{
    public class MDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public MDictionary() : base()
        {

        }

        public override bool Equals(object obj)
        {
            MDictionary<TKey, TValue> other = obj as MDictionary<TKey, TValue>;
            if (Count == other.Count)
            {
                for (int i = 0; i < Count; i++)
                {
                    TKey key = Keys.ElementAt(i);
                    if (!other.ContainsKey(key))
                    {
                        return false;
                    }

                    if (typeof(List<string>).IsInstanceOfType(other[key]) && typeof(List<string>).IsInstanceOfType(this[key]))
                    {
                        List<string> thisList = this[key] as List<string>;
                        List<string> list = other[key] as List<string>;
                        if (!thisList.SequenceEqual(list))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!(this[key].Equals(other[key])))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
