using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            LZW lzw = new LZW();

            string test = "herherher";
            string test2 = "abcAb";
            string testMikkel = "hej din fede nar nar nar nar nar narn det kunne være sjovt at tage en fejl";

            List<int> res = lzw.Compress(test);
            List<int> res2 = lzw.Compress(test2);

            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }

            //Performance.EvaluateSize(test, res);
            Performance.EvaluateSize(test2, res2);



            Console.ReadLine();
        }
    }
}
