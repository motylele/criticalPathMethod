using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPM
{
    static class Compare
    {
        public static bool In<T>(this T o, IEnumerable<T> values)
        {
            if (values == null) return false;

            return values.Contains(o);
        }
    }
}
