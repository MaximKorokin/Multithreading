using System.Collections.Generic;

namespace Multithreading.RaceCondition
{
    static class EnumerableExtensions
    {
        public static string ToString<T>(this IEnumerable<T> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
    }
}
