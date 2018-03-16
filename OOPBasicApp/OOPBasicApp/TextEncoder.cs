using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    class TextEncoder
    {
        private OOPBasics.Shared.IEncoder encoder;

        public TextEncoder(OOPBasics.Shared.IEncoder encoder)
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