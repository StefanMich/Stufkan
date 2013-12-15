using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Compression.Tests
{
    [TestClass()]
    public class HuffmanTests
    {
        Huffman h;
        [TestInitialize()]
        public void init()
        {
            h = new Huffman();
        }

        [TestMethod()]
        public void CreateHuffmanTreeFromFrequenciesTest()
        {
            string s = "aaabbc";
            List<Huffman.CharacterValuePair> freq = h.CalculateFrequencies(s);

            Huffman.CharacterValuePair res=  h.CreateHuffmanTreeFromFrequencies(freq);

            //Muligvis ikke den bedste assertion
            Assert.AreEqual(res.Value,6);
        }

        [TestMethod()]
        public void CalculateFrequenciesTest()
        {
            string s = "aaabbc";
            List<Huffman.CharacterValuePair> res = h.CalculateFrequencies(s);


            Assert.AreEqual(res[0].Value, 3);
            Assert.AreEqual(res[1].Value, 2);
            Assert.AreEqual(res[2].Value, 1);
        }

        [TestMethod()]
        public void CreatePrefixCodeTest()
        {
            string s = "aaabb.D";
            Huffman.CharacterValuePair root= h.CreateHuffmanTree(s);
            Dictionary<char,string> dict = h.CreatePrefixCode(root);

            Assert.AreEqual(dict['a'], "0");
            Assert.AreEqual(dict['b'], "10");
            Assert.AreEqual(dict['D'], "110");
            Assert.AreEqual(dict['.'], "111");
        }

        [TestMethod()]
        public void CreateHuffmanTreeTest1()
        {
            Assert.Fail();
        }
    }
}
