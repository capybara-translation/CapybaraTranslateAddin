using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace CapybaraTranslateAddin
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            if (chunksize <= 0) throw new ArgumentException();
            var loopCount = source.Count() / chunksize + (source.Count() % chunksize > 0 ? 1 : 0);
            foreach (var i in Enumerable.Range(0, loopCount))
            {
                yield return source.Skip(chunksize * i).Take(chunksize);
            }
        }

        public static List<Range> ToList(this Range range)
        {
            var list = new List<Range>();
            foreach (Range r in range)
            {
                list.Add(r);
            }

            return list;
        }
    }
}