using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasicApp
{
    class EnigmaEncoder: IEncoder
    {
        private byte startRange;
        private byte endRange;
        private byte rand;

        public EnigmaEncoder(byte n1, byte n2, byte rand)
        {
            
            this.startRange = n1;
            this.endRange = n2;
            this.rand = rand;
            
        }

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
            byte e = (byte)(startRange + (byteToEncode + rand) % (endRange - startRange));
            return e;
        }
    }
}