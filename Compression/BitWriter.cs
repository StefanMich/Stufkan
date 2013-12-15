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
        int remaining = 0;
        public BitWriter()
        {
            stream = new List<byte>();
        }

        public void WriteBits(string s)
        {
            if (remaining < s.Length)
            { 
                
            }
        }

        private byte StringToByte(string s)
        {
            byte b = 0x0;
            int index = 0;

            foreach (char c in s)
            {
                /*
                if (c == '1')
                    b &= 0x1 >> index;
                else b &= 0x0 >> index;
                 */
            }
            throw new NotImplementedException();
        }
    }
}
