using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    public class LZW
    {
        private const int DICTIONARY_SIZE = 256;
        public List<int> Compress(string uncompressed)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            List<int> compressed = new List<int>();

            for (int i = 0; i < DICTIONARY_SIZE; i++)
            {
                d.Add(((char)i).ToString(), i);
            }

            string w = string.Empty;



            for (int i = 0; i < uncompressed.Length; i++)
            {
                string wc = w + uncompressed[i];
                if (d.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    //Console.WriteLine(wc + " " + d.Count);
                    d.Add(wc, d.Count);
                    compressed.Add(d[w]);
                    w = uncompressed[i].ToString();
                }
            }

            if (!string.IsNullOrEmpty(w))
                compressed.Add(d[w]);

            return compressed;
        }

        public string Decompress(List<int> compressed)
        {
            Dictionary<int, string> d = new Dictionary<int, string>();

            for (int i = 0; i < DICTIONARY_SIZE; i++)
            {
                d.Add(i, ((char)i).ToString());
            }

            string prev = d[compressed[0]];
            compressed.RemoveAt(0);
            StringBuilder uncompressed = new StringBuilder(prev);

            foreach (var item in compressed)
            {
                string entry = null;
                if (d.ContainsKey(item))
                {
                    entry = d[item];
                }
                else if(item == d.Count)
                {
                    entry= prev + prev[0];
                }
                uncompressed.Append(entry);

                    d.Add(d.Count, prev+entry[0]);
                
                    prev = entry;

                
            }

            return uncompressed.ToString();
        }

    }
}
