using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_FileJsonSerialise_Due14Nov.Extentions
{
    internal static class ListHelpers
    {
        public static void Dump<T>(this IList<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
