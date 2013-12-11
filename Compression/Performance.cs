using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    public class Performance
    {
        public static void EvaluateSize(string uncompressed, List<int> compressed)
        {
            float orig = uncompressed.Length;
            float comp = compressed.Count;

            float reduce = ((orig - comp) / orig)*100;

            Console.WriteLine("The original string was " + orig + " characters long");
            Console.WriteLine("The compressed string is " + comp + " chacarcters long");
            Console.WriteLine("The compression resulted in a " + reduce + "% reduction in size");
        }
    }
}
