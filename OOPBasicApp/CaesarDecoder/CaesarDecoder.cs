using System;
using OOPBasics.Shared;
using System.Text;

namespace OOPBasics.CaesarDecoder
{
    class CaesarDecoder: IDecoder
    {
        private static readonly byte offset = 3;

        public byte[] Decode(byte[] inputData)
        {
           
            for (int i = 0; i < inputData.Length; i++)
            {
                inputData[i] = DecodeByte(inputData[i]);
            }
            return inputData;
        }



        private byte DecodeByte(byte charToDecode)
        {
            byte e = (byte)((charToDecode - offset) % 128);
            return e;
        }
    }
}
