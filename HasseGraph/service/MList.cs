using System.Collections.Generic;
using System.Linq;

namespace service
{
    public class MList<T> : List<T>
    {
        public MList() : base() { }

        internal new void Add(T item)
        {
            base.Add(item);
        }
    }
}
