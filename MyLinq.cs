using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace QueriesLinq
{
    public static class MyLinq
    {
        //quering infinity(create ienumerable method)
        public static IEnumerable<double> Random()
        {
            var random = new Random();
            while (true)
            {
                yield return random.NextDouble();
            }
        }


        //creating a custom filter operator method as an extension
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach(var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
