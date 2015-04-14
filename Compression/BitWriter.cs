using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    public class BitWriter
    {
        List<byte> stream;
        int remaining = 8;
        public BitWriter()
        {
            stream = new List<byte>();
            stream.Add(0);
        }

        public int NumberOfBits { get { return stream.Count * 8 + (8 - remaining); } }

        public List<byte> ByteStream { get { return stream; } }
        public void WriteBits(string s)
        {
            string temp = s;
            while (temp.Length > 8)
            {
                string str = temp.Substring(0, 8);
                temp = temp.Remove(0, 8);
                WriteByte(str);
            }
            WriteByte(temp);
        }

        private void WriteByte(string s)
            {
                byte b = StringToByte(s);

                if (remaining < s.Length)
                {
                    stream[stream.Count - 1] |= (byte)(b >> (s.Length - remaining));
                    stream.Add((byte)(b << remaining));
                    remaining = s.Length - remaining;
                }
                else
                {
                    stream[stream.Count - 1] |= (byte)(b << (remaining - s.Length));
                    remaining = remaining - s.Length;
                }
        }

        private byte StringToByte(string s)
        {
            byte b = 0;

            foreach (char c in s)
            {
                b = (byte)(b << 1);

                if (c == '1')
                    b |= 1;
                
            }
            return b;
        }
    }
}
