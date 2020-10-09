using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Service.Util
{
    public class MDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public MDictionary() : base() {
        }
        public MDictionary(IDictionary<TKey, TValue> dict) : base(dict) {
        }

        public override bool Equals(object obj)
        {
            MDictionary<TKey, TValue> other = obj as MDictionary<TKey, TValue>;
            if (other == null || Count != other.Count) { return false; }
            for (int i = 0; i < Count; i++)
            {
                TKey key = Keys.ElementAt(i);
                if (!other.ContainsKey(key) || !valuesEqualWithOtherMap(key, other))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool valuesEqualWithOtherMap(TKey key, MDictionary<TKey, TValue> other)
        {
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
            return true;
        }

        public ReadOnlyDictionary<TKey, TValue> getReadOnlyDictionary(){
             return new ReadOnlyDictionary<TKey, TValue>(this);
        }
    }
}
