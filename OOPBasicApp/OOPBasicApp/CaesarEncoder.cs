using System;
using System.Collections.Generic;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    class CaesarEncoder: IEncoder
    {
        private static readonly byte offset = 3;

       
        public byte[] Encode(byte[] inputData)
        {
            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = EncodeByte(inputData[i]);
            }
            return inputData;
        }

        private byte EncodeByte(byte byteToEncode)
        {
            byte e = (byte)((byteToEncode + offset) % 128);
            return e;
        }

    }
}
