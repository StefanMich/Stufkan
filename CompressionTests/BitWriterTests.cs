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
    public class BitWriterTests
    {
        [TestInitialize()]
        public void init()
        {

        }

        [TestMethod()]
        public void BitWriterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WriteBitsTest()
        {
            BitWriter w = new BitWriter();

            w.WriteBits("1101");
            List<byte> bytes = w.ByteStream;

            if (bytes.Count > 1) Assert.Fail("There is more than one byte in the list");

            int res = bytes[0] ^ 208;

            Assert.AreEqual(res, 0);
        }


        [TestMethod()]
        public void WriteBitsTest2()
        {
            BitWriter w = new BitWriter();

            w.WriteBits("1101");
            w.WriteBits("11101111");

            List<byte> bytes = w.ByteStream;

            if (bytes.Count > 2) Assert.Fail("There is more than one byte in the list");

            int res1 = bytes[0] ^ 222;
            int res2 = bytes[1] ^ 240;

            int res = res1 ^ res2;

            Assert.AreEqual(res, 0);
        }

        [TestMethod()]
        public void WriteBitsTest3()
        {
            BitWriter w = new BitWriter();

            w.WriteBits("1110111100110011");

            List<byte> bytes = w.ByteStream;

            if (bytes.Count > 2) Assert.Fail("There is more than one byte in the list");

            int res1 = bytes[0] ^ 222;
            int res2 = bytes[1] ^ 240;

            int res = res1 ^ res2;

            Assert.AreEqual(res, 0);

        }
    }
}
