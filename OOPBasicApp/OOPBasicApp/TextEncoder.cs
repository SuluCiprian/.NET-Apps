using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    class TextEncoder
    {
        private IEncoder encoder;

        public TextEncoder(IEncoder encoder)
        {
            this.encoder = encoder;
        }

        public byte[] Encode(string inputString)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputString);
            return encoder.Encode(bytes);
        }
    }
}