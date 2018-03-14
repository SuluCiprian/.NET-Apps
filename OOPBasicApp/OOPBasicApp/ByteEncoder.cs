using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    class ByteEncoder
    {
        private byte n1;
        private byte n2;
        private byte rand;

        public ByteEncoder()
        {
            Random rnd = new Random();
            n1 = 250;
            n2 = 100;
            rand = (byte)rnd.Next(128);
        }

        public byte[] Encode(byte[] inputData)
        {
            for(int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = EncodeByte(inputData[i]);
            }
            return inputData;
        }

        private byte EncodeByte(byte byteToEncode)
        {
            byte e = (byte)(n1 + (byteToEncode + rand) % (n2 - n1));
            return e;
        }
    }
}
