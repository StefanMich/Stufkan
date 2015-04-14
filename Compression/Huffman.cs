using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Compression
{
    public class Huffman
    {
        public void Encode(string s, string filename)
        {
            BinaryWriter t = new BinaryWriter(File.Open(filename, FileMode.Create));

            List<CharacterValuePair> freq = CalculateFrequencies(s);
            WriteFrequencies(freq, t);

            CharacterValuePair tree = CreateHuffmanTreeFromFrequencies(freq);

            Dictionary<char, string> prefixCodes = CreatePrefixCode(tree);

            BitWriter w = EncodeString(s, prefixCodes);

            t.Write('\n');
            t.Write(w.NumberOfBits);
            foreach (byte b in w.ByteStream)
            {
                t.Write(b);
            }

            t.Close();
        }

        public string Decode(string filename)
        {
            BinaryReader stream = new BinaryReader(File.Open(filename, FileMode.Open));

            List<CharacterValuePair> freq = ReadFrequencies(stream);

            List<byte> message = new List<byte>();

            while (stream.PeekChar() != -1)
                message.Add(stream.ReadByte());


            CharacterValuePair tree = CreateHuffmanTreeFromFrequencies(freq);

            //decode the bytes from the tree
            //return string
            throw new NotImplementedException();
        }

        private string ReadMessage(CharacterValuePair tree, string message)
        {
            throw new NotImplementedException();
        }

        private char ReadPrefixCode(char encoded, CharacterValuePair tree)
        {
            throw new NotImplementedException();
        }

        private List<CharacterValuePair> ReadFrequencies(BinaryReader stream)
        {
            List<CharacterValuePair> freq = new List<CharacterValuePair>();

            char peek = (char)stream.PeekChar();

            while (peek != '\n')
            {
                char key = stream.ReadChar();
                int value = stream.ReadInt32();
                freq.Add(new CharacterValuePair(key, value));
                peek = (char)stream.PeekChar();
            }

            return freq;
        }

        public void WriteFrequencies(List<CharacterValuePair> freq, BinaryWriter s)
        {
            foreach (var item in freq)
            {
                s.Write(item.Key);
                s.Write(item.Value);
            }
        }

        public BitWriter EncodeString(string s, Dictionary<char, string> prefixcodes)
        {
            BitWriter w = new BitWriter();

            foreach (char c in s)
            {
                w.WriteBits(prefixcodes[c]);
            }
            return w;
        }

        public Dictionary<char, string> CreatePrefixCode(CharacterValuePair root)
        {
            Dictionary<char, string> prefixCodes = new Dictionary<char, string>();
            TraverseTree(root, prefixCodes, "");

            return prefixCodes;
        }

        private void TraverseTree(CharacterValuePair node, Dictionary<char, string> dict, string prefix)
        {
            if (node.Left.Key == 'x')
                TraverseTree(node.Left, dict, prefix + "0");
            else dict.Add(node.Left.Key, prefix + "0");

            if (node.Right.Key == 'x')
                TraverseTree(node.Right, dict, prefix + "1");
            else dict.Add(node.Right.Key, prefix + "1");
        }

        public CharacterValuePair CreateHuffmanTreeFromFrequencies(List<CharacterValuePair> C)
        {
            int n = C.Count;
            MinPriorityQueue<CharacterValuePair> Q = new MinPriorityQueue<CharacterValuePair>(C);

            for (int i = 0; i < n - 1; i++)
            {
                CharacterValuePair left = Q.HeapExtract();
                CharacterValuePair right = Q.HeapExtract();
                CharacterValuePair z = new CharacterValuePair('x', left.Value + right.Value);
                z.Left = left;
                z.Right = right;

                Q.Insert(z);
            }
            return Q.HeapExtract();
        }

        public List<CharacterValuePair> CalculateFrequencies(string s)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();

            for (int i = 0; i <= 127; i++)
            {
                if (s.Contains((char)i))
                    frequencies[(char)i] = 0;
            }


            foreach (char item in s)
            {
                frequencies[item]++;
            }

            List<CharacterValuePair> frequencylist = new List<CharacterValuePair>();
            foreach (var item in frequencies)
            {
                frequencylist.Add(new CharacterValuePair(item.Key, item.Value));
            }

            return frequencylist;
        }

        public class CharacterValuePair : IComparable<CharacterValuePair>
        {
            private KeyValuePair<char, int> keyvaluepair;

            private CharacterValuePair left;
            private CharacterValuePair right;
            private CharacterValuePair parent;
            public CharacterValuePair(char c, int i)
            {
                keyvaluepair = new KeyValuePair<char, int>(c, i);
            }

            public CharacterValuePair Left { get { return left; } set { left = value; } }
            public CharacterValuePair Right { get { return right; } set { right = value; } }
            public CharacterValuePair Parent { get { return parent; } set { parent = value; } }
            public char Key { get { return keyvaluepair.Key; } }

            public int Value { get { return keyvaluepair.Value; } }

            public override string ToString()
            {
                return this.Key + " " + this.Value.ToString();
            }

            public int CompareTo(CharacterValuePair other)
            {
                if (other == null) return 1;

                return this.keyvaluepair.Value.CompareTo(other.keyvaluepair.Value);
            }
        }
    }
}
