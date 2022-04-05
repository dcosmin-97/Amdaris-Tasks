using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Extensions
{
    public static class ListExtension
    {
        public static IEnumerable<T> ListFilter<T>(this List<T> items, Func<T, bool> predicate, Func<T, bool> predicate2)
        {
            foreach (var item in items)
            {
                if (predicate(item) && predicate2(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> ListFilter2<T>(this List<T> items, Func<T, int, bool> predicate)
        {
            int arg2 = items.Count;
            foreach (var item in items)
            {
                if (predicate(item, arg2))
                {
                    yield return item;
                }
            }
        }
    }
}
