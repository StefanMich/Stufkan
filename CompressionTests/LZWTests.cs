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
    public class LZWTests
    {
        private LZW lzw;
        [TestInitialize()]
        public void Initialize()
        {
            lzw = new LZW();
        }

        [TestMethod()]
        public void CompressDecompressTest()
        {
            string test = "hererderkage";
            string res = lzw.Decompress( lzw.Compress(test));

            Assert.AreEqual(test, res);
        }

        /// <summary>
        /// problematic string according to http://michael.dipperstein.com/lzw/
        /// </summary>
        [TestMethod()]
        public void CompressDecompressExceptionTest()
        {
            string test = "abcabcabcabcabcabc";
            string res = lzw.Decompress( lzw.Compress(test));

            Assert.AreEqual(test, res);
        }
    }
}
