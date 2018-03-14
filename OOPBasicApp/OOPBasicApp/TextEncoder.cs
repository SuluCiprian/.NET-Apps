using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    class TextEncoder
    {
        private ByteEncoder byteEncoder;

        public byte[] Encode(string inputString)
        {
            byteEncoder = new ByteEncoder();
            byte[] bytes = Encoding.ASCII.GetBytes(inputString);
            return byteEncoder.Encode(bytes);
        }
    }
}
