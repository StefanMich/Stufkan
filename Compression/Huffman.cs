using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Compression
{
    public class Huffman
    {

        public CharacterValuePair CreateHuffmanTree(string s)
        {
            List<CharacterValuePair> freq = CalculateFrequencies(s);
            return CreateHuffmanTreeFromFrequencies(freq);
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

            for (int i = 65; i <= 90; i++)
            {
                if (s.Contains((char)i) || s.Contains((char)(i+32) ))
                    frequencies[(char)i] = 0;
            }


            foreach (char item in s)
            {
                frequencies[Char.ToUpper(item)]++;
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
