using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Huffman h = new Huffman();

            string s = "";

            h.Encode("hej din ", "test");
            s = h.Decode("test");

            Console.WriteLine(s);
            


            
            //LZW lzw = new LZW();

            //string test = "herherher";
            //string test2 = "abcdefghijklmnopqrstuvw";
            

            //List<int> res = lzw.Compress(test);
            //List<int> res2 = lzw.Compress(test2);

            //foreach (var item in res2)
            //{
            //    Console.WriteLine(item);
            //}

            ////Performance.EvaluateSize(test, res);
            //Performance.EvaluateSize(test2, res2);


            
            Console.ReadLine();
        }

    }
}
